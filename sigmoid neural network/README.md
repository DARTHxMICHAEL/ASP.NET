Sieć neuronowa oparta na neuronach sigmoidalnych. Neurony ukryte wykorzystują funkcję unipolarną (jedna wartwa sieci ukrytej). Dwa wejściowe (+bias), trzy neurony warstwy ukrytej (+bias) i jedno wyjście. Taka struktura dobrze stymuluje naukę i znacząco ułatwia interpretacje wyników.

Uczenie odbywa się w trybie z nauczycielem poprzez minimalizację funkcji celu. Ciągłość funkcji (różniczkowalność) umożliwia zastosowanie metody gradientowej. W celu ograniczenia ryzyka 'utknięcia w minimum lokalnym aktualizacja wag odbywa się z momentum (aktualizacja dyskretna). Maksymalny dopuszczalny błąd na poziomie 5%. Użytkownik ustala liczbę epok- powtórzeń treningowych w ramach których zostaną wykorzystane wszystkie przypadki uczące (8).

Kod nie jest mój! Jednak zmodyfikowałem go pod kątem trzy elementowego problemu XOR i zoptymalizowałem pod to właśnie zastosowanie. Przy pracy korzystałem z książki 'Sieci neuronowe do przetwarzania informacji' Stanisława Osowskiego.
