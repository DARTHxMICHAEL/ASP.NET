using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;



public partial class NeuralNetworkSource : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { }

    //zmienne globalne
    public int trainingLoop;

    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";

        int trainingNo = int.Parse(TextBox2.Text);
        int hiddenNeurons = int.Parse(TextBox3.Text);

        TextBox1.Text = "POCZĄTEK TRENINGU \r\n";
        trainingLoop = 0;

        NeuralNetwork nn = new NeuralNetwork(2, hiddenNeurons, 1);
        nn.Change += new NeuralNetwork.ChangeHandler(nn_Change);
        NN_Trainer_XOR trainer = new NN_Trainer_XOR(ref nn);
        trainer.Change += new NN_Trainer_XOR.ChangeHandler(trainer_Change);

        Button1.Enabled = false;
        trainer.doTraining(trainingNo);
        TextBox1.Text += "KONIEC TRENINGU " + "\r\n";
        trainer.doActualRun();
        Button1.Enabled = true;
    }


    /// <summary>
    /// Uses the data contained in the event args, to add to the 
    /// live values text box, and also create the required chart
    /// data from the data
    /// </summary>
    /// <param name="nne">The event args</param>
    private void show_NeuralNetwork_Results(NeuralNetworkEventArgs nne)
    {
        //pobranie danych do pokazania
        double[] targOuts = nne.TargetOuts;
        double[] outputs = nne.Outputs;

        for (int i = 0; i < targOuts.Length; i++)
        {
            TextBox1.Text += (NeuralNetwork.isInTraining ? "Epoka: " + trainingLoop + " " : "");
            TextBox1.Text += "Wyjście : " + outputs[i].ToString("#,##0.00")
            + " / Oczekiwane wyjście : " + targOuts[i] + "\r\n";
        }   
    }


    /// <summary>
    /// The Change event which is raised by the 
    /// <see cref="NeuralNetwork">NeuralNetwork</see>
    /// This method then calls the show_NeuralNetwork_Results()
    /// method
    /// </summary>
    /// <param name="sender">The <see cref="NeuralNetwork">NeuralNetwork</see></param>
    /// <param name="nne">The event args</param>
    private void nn_Change(object sender, NeuralNetworkEventArgs nne)
    {
        if (NeuralNetwork.isInTraining)
        {
            //only show every 100th result
            if (trainingLoop % 100 == 0)
            {
                show_NeuralNetwork_Results(nne);
            }
        }
        else
        {
            //not in traning, so show ALL results
            show_NeuralNetwork_Results(nne);
        }
    }


    /// <summary>
    /// The Change event which is raised by the 
    /// <see cref="NN_Trainer_XOR">trainer</see>
    /// This method simplu updates the trainingLoop with
    /// the current trainers loop number
    /// </summary>
    /// <param name="sender">The <see cref="NN_Trainer_XOR">trainer</see></param>
    /// <param name="te">The training args</param>
    private void trainer_Change(object sender, TrainerEventArgs te)
    {
        trainingLoop = te.TrainingLoop;
    }


// NEURAL NETWORK CONSTRUCTION

#region NeuralNetwork CLASS
    /// <summary>
    /// Represents a multi layer nueral network, that has n-many
    /// input nodes, n-many hidden nodes, and n-many output nodes.
    /// This class provides a method to do a full forward through
    /// network for a set of applied inputs
    /// </summary>
    public class NeuralNetwork
{
    #region Instance Fields
    //private fields
    private int num_in;
    private int num_hid;
    private int num_out;
    private double[,] i_to_h_wts;
    private double[,] h_to_o_wts;
    private double[] inputs;
    private double[] hidden;
    private double[] outputs;
    private double learningRate = 0.3;
    private Random gen = new Random();
    //public fields
    public static bool isInTraining;
    public delegate void ChangeHandler(Object sender, NeuralNetworkEventArgs nne);
    public event ChangeHandler Change;

    #endregion
    #region Constructor
    /// <summary>
    /// Creates a new NeuralNetwork, using the parameters
    /// provided
    /// </summary>
    /// <param name="num_in">Number of inputs nodes</param>
    /// <param name="num_hid">Number of hidden nodes</param>
    /// <param name="num_out">Number of output nodes</param>
    public NeuralNetwork(int num_in, int num_hid, int num_out)
    {
        this.num_in = num_in;
        this.num_hid = num_hid;
        this.num_out = num_out;
        i_to_h_wts = new double[num_in + 1, num_hid];
        h_to_o_wts = new double[num_hid + 1, num_out];
        inputs = new double[num_in + 1];
        hidden = new double[num_hid + 1];
        outputs = new double[num_out];
    }
    #endregion
    #region Initialization of random weights
    /// <summary>
    /// Randomly initialise all the network weights.
    /// Need to start with some weights. 
    /// This method sets up the input to hidden nodes and
    /// hidden nodes to output nodes with random values
    /// </summary>
    public void initialiseNetwork()
    {
        // Set the input value for bias node
        inputs[num_in] = 1.0;
        hidden[num_hid] = 1.0;
        // Set weights between input & hidden nodes.
        for (int i = 0; i < num_in + 1; i++)
        {
            for (int j = 0; j < num_hid; j++)
            {
                // Set random weights between -2 & 2
                i_to_h_wts[i, j] = (gen.NextDouble() * 4) - 2;
            }
        }
        // Set weights between hidden & output nodes.
        for (int i = 0; i < num_hid + 1; i++)
        {
            for (int j = 0; j < num_out; j++)
            {
                // Set random weights between -2 & 2
                h_to_o_wts[i, j] = (gen.NextDouble() * 4) - 2;
            }
        }
    }
    #endregion
    #region Events
    /// <summary>
    /// Raises the Change event
    /// </summary>
    /// <param name="nne">The NeuralNetworkEventArgs</param>
    public virtual void On_Change(NeuralNetworkEventArgs nne)
    {
        if (Change != null)
        {
            // Invokes the delegates. 
            Change(this, nne);
        }
    }
    #endregion
    #region Pass forward
    /// <summary>
    /// Does a complete pass through within the network, using the
    /// applied_inputs parameters. The pass thorugh is done to the
    /// input to hidden, and hidden to ouput layers
    /// </summary>
    /// <param name="applied_inputs">An double[] array which holds input values, which
    /// are then preseted to the networks input layer</param>
    /// <param name="targOuts">An double[] array which holds what the outputs should
    /// be for this set of inputs being presented to the network</param>
    public void pass_forward(double[] applied_inputs, double[] targOuts)
    {
        // Load a set of inputs into our current inputs
        for (int i = 0; i < num_in; i++)
        {
            inputs[i] = applied_inputs[i];
        }
        // Forward to hidden nodes, and calculate activations in hidden layer
        for (int i = 0; i < num_hid; i++)
        {
            double sum = 0.0;
            for (int j = 0; j < num_in + 1; j++)
            {
                sum += inputs[j] * i_to_h_wts[j, i];
            }
            hidden[i] = SigmoidActivationFunction.processValue(sum);
        }
        // Forward to output nodes, and calculate activations in output layer
        for (int i = 0; i < num_out; i++)
        {
            double sum = 0.0;
            for (int j = 0; j < num_hid + 1; j++)
            {
                sum += hidden[j] * h_to_o_wts[j, i];
            }
            //pass the sum, through the activation function, Sigmoid in this case
            //which allows for backward differentation
            outputs[i] = SigmoidActivationFunction.processValue(sum);

            //Fire the Change event, so that who ever has subscribed to the Change event
            //may use the present Neural Network results
            NeuralNetworkEventArgs nne = new NeuralNetworkEventArgs(outputs, targOuts);
            On_Change(nne);
        }
    }
    #endregion
    #region Public Properties

    /// <summary>
    /// gets / sets the number of input nodes for the Neural Network
    /// </summary>
    public int NumberOfInputs
    {
        get { return num_in; }
        set { num_in = value; }
    }

    /// <summary>
    /// gets / sets the number of hidden nodes for the Neural Network
    /// </summary>
    public int NumberOfHidden
    {
        get { return num_hid; }
        set { num_hid = value; }
    }

    /// <summary>
    /// gets / sets the number of output nodes for the Neural Network
    /// </summary>
    public int NumberOfOutputs
    {
        get { return num_out; }
        set { num_out = value; }
    }

    /// <summary>
    /// gets / sets the input to hidden weights for the Neural Network
    /// </summary>
    [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
    public double[,] InputToHiddenWeights
    {
        get { return i_to_h_wts; }
        set { i_to_h_wts = value; }
    }

    /// <summary>
    /// gets / sets the hidden to output weights for the Neural Network
    /// </summary>
    [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
    public double[,] HiddenToOutputWeights
    {
        get { return h_to_o_wts; }
        set { h_to_o_wts = value; }
    }

    /// <summary>
    /// gets / sets the input values for the Neural Network
    /// </summary>
    [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
    public double[] Inputs
    {
        get { return inputs; }
        set { inputs = value; }
    }

    /// <summary>
    /// gets / sets the hidden values for the Neural Network
    /// </summary>
    [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
    public double[] Hidden
    {
        get { return hidden; }
        set { hidden = value; }
    }

    /// <summary>
    /// gets / sets the outputs values for the Neural Network
    /// </summary>
    [Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
    public double[] Outputs
    {
        get { return outputs; }
        set { outputs = value; }
    }

    /// <summary>
    /// gets / sets the LearningRate (eta) value for the Neural Network
    /// </summary>
    public double LearningRate
    {
        get { return learningRate; }
        set { learningRate = value; }
    }
    #endregion
}
#endregion

#region NeuralNetworkEventArgs CLASS

/// <summary>
/// Provides the event argumets for the 
/// <see cref="NeuralNetwork">NeuralNetwork</see> class
/// </summary>
public class NeuralNetworkEventArgs : EventArgs
{
    #region Instance Fields
    private double[] targOuts;
    private double[] outputs;
    #endregion
    #region Public Constructor
    /// <summary>
    /// Constructs a new NeuralNetworkEventArgs object using the parameters provided
    /// </summary>
    /// <param name="outputs">the actual output array</param>
    /// <param name="targOuts">the target output array</param>
    public NeuralNetworkEventArgs(double[] outputs, double[] targOuts)
    {
        this.targOuts = targOuts;
        this.outputs = outputs;
    }
    #endregion
    #region Public Methods/Properties

    /// <summary>
    /// gets the target outputs(s)
    /// </summary>
    public double[] TargetOuts
    {
        get { return targOuts; }
    }

    /// <summary>
    /// gets the actual outputs(s)
    /// </summary>
    public double[] Outputs
    {
        get { return outputs; }
    }
    #endregion
}
#endregion

#region SigmoidActivationFunction CLASS
/// <summary>
/// Provides a sigmoid activation function
/// </summary>
public class SigmoidActivationFunction
{
    /// <summary>
    /// Takes a value for a current network node, and applies a sigmoid
    /// activation function to it, which is then returned
    /// </summary>
    /// <param name="x">The value to apply the activation to</param>
    /// <returns>The activation value, after a sigmoid function</returns>
    public static double processValue(double x)
    {
        return 1.0 / (1.0 + Math.Pow(Math.E, -x));
    }
}
#endregion

// END OF NEURAL NETWORK CONSTRUCTION


// NEURAL NETWORK TRAINING 

#region NN_Trainer_XOR CLASS
/// <summary>
/// Provides a XOR trainer for a
/// <see cref="NeuralNetwork">NeuralNetwork</see> class
/// with 2 inputs, 2 hidden, and 1 output
/// </summary>
public class NN_Trainer_XOR
{

    #region Instance fields
    private NeuralNetwork nn;
    private Random gen = new Random();
    private int training_times = 10000;
    private double[,] train_set =
        //{{0, 0},
        // {0, 1},
        // {1,0},
        // {1,1}};
            {{0, 0, 0},
             {0, 0, 1},
             {0, 1, 0},
             {1, 0, 0},
             {1, 1, 0},
             {0, 1, 1},
             {1, 0, 1},
             {1, 1, 1}};

    public delegate void ChangeHandler(Object sender, TrainerEventArgs te);
    public event ChangeHandler Change;

    #endregion
    #region Constructor
    /// <summary>
    /// Constructs a new NN_Trainer_XOR object. 
    /// This object is a specific trainer for training
    /// a NeuralNetwork with 2 inputs, 2 hidden nodes, a 1 output
    /// to try and solve the XOR problem.
    /// If you require the NeuralNetwork to be training for some other
    /// task, simply create a new trainer object for the task and ensure
    /// the nn input parameter has the correct number of inputs, hidden and
    /// outputs for the trainers task
    /// </summary>
    /// <param name="nn">A pre-configured neural network, with the
    /// correct number of inputs, hidden nodes, a outputs
    /// to try and solve the XOR problem</param>
    public NN_Trainer_XOR(ref NeuralNetwork nn)
    {
        this.nn = nn;
        nn.initialiseNetwork();
    }
    #endregion
    #region Events
    /// <summary>
    /// Raises the Change event
    /// </summary>
    /// <param name="te">The TrainerEventArgs</param>
    public virtual void On_Change(TrainerEventArgs te)
    {
        if (Change != null)
        {
            // Invokes the delegates. 
            Change(this, te);
        }
    }
    #endregion
    #region Public methods

    /// <summary>
    /// Is called after the initial training is completed.
    /// Siply presents 1 complete set of the training set to
    /// the trained XOR, which should hopefully get it pretty
    /// correct now its trained
    /// </summary>
    public void doActualRun()
    {
        NeuralNetwork.isInTraining = false;
        //loop through the entire training set
        for (int j = 0; j <= train_set.GetUpperBound(0); j++)
        {
            //and forward them through the network
            double[] targOut = getTargetValues(getTrainSet(j));
            nn.pass_forward(getTrainSet(j), targOut);
        }
    }

    /// <summary>
    /// Presents the exntire training set to the 
    /// <see cref="NeuralNetwork">NeuralNetwork</see>, as many
    /// times as specified by the training_times input parameter
    /// This will call the NeuralNetwork.pass_forward, and also
    /// call the train_network() methods
    /// </summary>
    /// <param name="training_times">the number of times to carry out the
    /// training loop</param>
    public void doTraining(int training_times)
    {
        NeuralNetwork.isInTraining = true;
        this.training_times = training_times;

        //loop for n-many training times
        for (int i = 0; i < this.training_times; i++)
        {

            TrainerEventArgs te = new TrainerEventArgs(i);
            On_Change(te);
            //loop through all training set examples
            for (int j = 0; j <= train_set.GetUpperBound(0); j++)
            {
                // Train using example set
                double[] targOut = getTargetValues(getTrainSet(j));
                //feed forward through network
                nn.pass_forward(getTrainSet(j), targOut);
                //do the weight changes (pass back)
                train_network(targOut);
            }
        }
    }
    #endregion
    #region Private methods

    /// <summary>
    /// Returns the array within the 2D train_set array as the index
    /// specfied by the idx input parameter
    /// </summary>
    /// <param name="idx">The index into the 2d array to get</param>
    /// <returns>The array within the 2D train_set array as the index
    /// specfied by the idx input parameter</returns>
    private double[] getTrainSet(int idx)
    {
        //NOTE :
        //
        //If anyone can tell me how to return an array at index idx from
        //a 2D array, which is holding arrays of arrays I would like that
        //very much.
        //I thought it would be
        //double[] trainValues= (double[])train_set.GetValue(0);
        //but this didn't work, so am doing it like this

        double[] trainValues = { train_set[idx, 0], train_set[idx, 1] };
        return trainValues;
    }

    /// <summary>
    /// The main training. The expected target values are passed in to this
    /// method as paramaters, and the <see cref="NeuralNetwork">NeuralNetwork</see> 
    /// is then updated with small weight changes, for this training iteration
    /// This method also applied momentum, to ensure that the NeuralNetwork is
    /// nurtured into proceeding in the correct direction. We are trying to avoid valleys.
    /// If you dont know what valleys means, read the articles associatd text
    /// </summary>
    /// <param name="target">A double[] array containing the target value(s)</param>
    private void train_network(double[] target)
    {
        //get momentum values (delta values from last pass)
        double[] delta_hidden = new double[nn.NumberOfHidden + 1];
        double[] delta_outputs = new double[nn.NumberOfOutputs];

        // Get the delta value for the output layer
        for (int i = 0; i < nn.NumberOfOutputs; i++)
        {
            delta_outputs[i] =
                nn.Outputs[i] * (1.0 - nn.Outputs[i]) * (target[i] - nn.Outputs[i]);
        }
        // Get the delta value for the hidden layer
        for (int i = 0; i < nn.NumberOfHidden + 1; i++)
        {
            double error = 0.0;
            for (int j = 0; j < nn.NumberOfOutputs; j++)
            {
                error += nn.HiddenToOutputWeights[i, j] * delta_outputs[j];
            }
            delta_hidden[i] = nn.Hidden[i] * (1.0 - nn.Hidden[i]) * error;
        }
        // Now update the weights between hidden & output layer
        for (int i = 0; i < nn.NumberOfOutputs; i++)
        {
            for (int j = 0; j < nn.NumberOfHidden + 1; j++)
            {
                //use momentum (delta values from last pass), 
                //to ensure moved in correct direction
                nn.HiddenToOutputWeights[j, i] += nn.LearningRate * delta_outputs[i] * nn.Hidden[j];
            }
        }
        // Now update the weights between input & hidden layer
        for (int i = 0; i < nn.NumberOfHidden; i++)
        {
            for (int j = 0; j < nn.NumberOfInputs + 1; j++)
            {
                //use momentum (delta values from last pass), 
                //to ensure moved in correct direction
                nn.InputToHiddenWeights[j, i] += nn.LearningRate * delta_hidden[i] * nn.Inputs[j];
            }
        }
    }

    /// <summary>
    /// Returns a double which represents the output for the
    /// current set of inputs.
    /// In the cases where the summed inputs = 1, then target
    /// should be 1.0, otherwise it should be 0.0. 
    /// This is only for the XOR problem, but this is a trainer
    /// for the XOR problem, so this is fine.
    /// </summary>
    /// <param name="currSet">The current set of inputs</param>
    /// <returns>A double which represents the output for the
    /// current set of inputs</returns>
    private double[] getTargetValues(double[] currSet)
    {
        //the current value of the training set
        double valOfSet = 0;
        double[] targs = new double[1];
        for (int i = 0; i < currSet.Length; i++)
        {
            valOfSet += currSet[i];
        }
        //in the cases where the summed inputs = 1, then target
        //should be 1.0, otherwise it should be 0.0
        targs[0] = valOfSet == 1 ? 1.0 : 0.0;
        return targs;
    }
    #endregion
}
#endregion

#region TrainerEventArgs CLASS
/// <summary>
/// Provides the event argumets for the 
/// <see cref="NN_Trainer_XOR">trainer</see> class
/// </summary>
public class TrainerEventArgs : EventArgs
{
    #region Instance Fields
    //Instance fields
    private int trainLoop = 0;

    #endregion
    #region Public Constructor

    /// <summary>
    /// Constructs a new TrainerEventArgs object using the parameters provided
    /// </summary>
    /// <param name="trainLoop">The current training loop</param>
    public TrainerEventArgs(int trainLoop)
    {
        this.trainLoop = trainLoop;
    }
    #endregion
    #region Public Methods/Properties

    /// <summary>
    /// gets the training loop number
    /// </summary>
    public int TrainingLoop
    {
        get { return trainLoop; }
    }
    #endregion

}
    #endregion

// END OF NEURAL NETWORK TRAINING 


}