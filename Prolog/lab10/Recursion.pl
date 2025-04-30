% задание 1
max(X,Y,X):- X>Y, !.
max(_,Y,Y).

% максимум 3-х чисел
max(X,Y,Z,U):- max(X,Y,V), max(V,Z,U).

max3(X,Y,Z,X):- X>Y, X>Z, !.
max3(_,Y,Z,Y):- Y>Z, !.
max3(_,_,Z,Z).

% сумма цифр вверх
sumCifr(0,0):-!.
sumCifr(N,S):- C is N mod 10, N1 is N div 10, sumCifr(N1,S1), S is S1+C.

% сумма цифр вниз
sumCifrDown(N,S):- sumCifrDown(N,0,S).
sumCifrDown(0,Sum,Sum):-!.
sumCifrDown(N,CurSum,S):- C is N mod 10, N1 is N div 10, NewCurSum is CurSum+C, sumCifrDown(N1,NewCurSum,S).

% списки
writeList([]):- !.
writeList([H|T]):- write(H), nl, writeList(T).

% сумма элементов списка вниз
sumCifrList([H|T],S):- sumCifrList([H|T],0, S).
sumCifrList([],Sum, Sum):- !.
sumCifrList([H|T],CurSum,Sum):- N is CurSum+H, sumCifrList(T,N,Sum).

% сумма элементов списка вверх
sumCifrListUp([],0).
sumCifrListUp([H|T],Sum):- sumCifrListUp(T,Sum1), Sum is H+Sum1.

% Удаление элементов с равной суммой цифр заданному числу
remove_if_sum_equal([], _, []).
remove_if_sum_equal([X|T], TargetSum, Result) :-
    number_chars(X, CharList),
    maplist(atom_number, CharList, Digits),
    sumCifrList(Digits, Sum),
    (Sum =:= TargetSum -> remove_if_sum_equal(T, TargetSum, Result);
        Result = [X | NewResult], remove_if_sum_equal(T, TargetSum, NewResult)).

% задание 2
% Вариант № 6

% 1. Найти минимальную цифру числа.
% Рекурсия вниз
min_digit_down(N, Min) :- min_digit_down(N, 9, Min).
min_digit_down(0, Min, Min) :- !.                               
min_digit_down(N, CurMin, Min) :-                              
    Digit is N mod 10,                                          % последняя цифра
    Rest is N // 10,                                            % отброс последней цифры
    NewMin is min(CurMin, Digit),                               % новый минимум
    min_digit_down(Rest, NewMin, Min).

% Рекурсия вверх
min_digit_up(N, Min) :- N < 10, Min is N, !.
min_digit_up(N, Min) :-
    Digit is N mod 10,
    Rest is N // 10,
    min_digit_up(Rest, MinRest),
    Min is min(Digit, MinRest).

% 2. Найти количество цифр числа, меньших 3
% Рекурсия вниз
countDigitsLessThan3(N, Count) :- count_digits_less_than_3(N, 0, Count). 
count_digits_less_than_3(0, Acc, Acc) :- !.
count_digits_less_than_3(N, Acc, Count) :-
    Digit is N mod 10,                                % берём последнюю цифру
    Rest is N // 10,                                  % убираем её
    (Digit < 3 -> NewAcc is Acc + 1 ; NewAcc = Acc),  % увеличиваем счётчик, если < 3
    count_digits_less_than_3(Rest, NewAcc, Count).


% Рекурсия вверх
countDigitsLessThan3Up(N, Count) :-
    ( N < 10 -> ( N < 3 -> Count = 1 ; Count = 0);   % если одна цифра — сразу считаем
        Digit is N mod 10,                           % последняя цифра
        Rest is N // 10,                             % отброс последней
        countDigitsLessThan3Up(Rest, CountRest),
        (Digit < 3 -> Count is CountRest + 1 ; Count = CountRest)
    ).

% 3. Найти количество делителей числа
% Рекурсия вниз
count_divisors(N, Count) :- count_divisors(N, 1, 0, Count).
count_divisors(N, I, Acc, Acc) :- I > N, !.
count_divisors(N, I, Acc, Count) :-
    (N mod I =:= 0 -> NewAcc is Acc+1 ; NewAcc=Acc),  % если I делит N, увеличиваем счёт
    NextI is I+1,
    count_divisors(N, NextI, NewAcc, Count).

% Рекурсия вверх
countDivisorsUp(N, Count) :- countDivisorsUp(N, 1, Count).
countDivisorsUp(N, I, 0) :- I > N, !.
countDivisorsUp(N, I, Count) :-
    I =< N,
    countDivisorsUp(N, I + 1, RestCount),
    (N mod I =:= 0 -> Count is RestCount + 1 ; Count = RestCount).
