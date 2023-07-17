Prosta gra napisana w Unity wykorzystujaca genetyczne sieci neuronowe. Ptaki mają za zadanie dolecieć jak najbliżej hexagonu (nagrody, w oparciu o odległość 
ustalana jest wartość fitness każdej sieci), w miarę możliowści omijając przy tym wszelkiego rodzaju przeszkody przy wykorzystaniu 6 sensorów odległości.

Sieć(i) wykorzystuje tangensoidalną funkcję aktywacji. Wagi początkowe są losowane z zakresu [-0.5,0.5]. Wagi sumowane liniowo. Sieć składa się 6 neuronów wejściowych, 
następnie kolejno 4 oraz 3 w warstwach ukrytych i jednego wyjścia. Na podstawie wartości wyjściowej (0,1) ustalana jest trajektoria lotu danego ptaka. W oprciu o wartość
fitness (dopasowania) mutacji podlega gorsza połowa sieci. Mutacje obejmują cztery warianty, współczynnik mutacji wag wynosi 8%.

![screen](https://github.com/DARTHxMICHAEL/ASP.NET/blob/main/genetic%20neural%20network/20230108_222313.jpg?raw=true)

