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

% задание 3

% 6. Дан целочисленный массив. Необходимо осуществить циклический сдвиг элементов массива влево на три позиции.
read_list(List) :- write('Введите список (через точку с запятой, например [1,2,3,4]): '), nl, read(List).
print_list(List) :- write('Результат: '), write(List), nl.
shift_left_3(List, Result) :-
    length(Prefix, 3),           % берем первые 3 элемента
    append(Prefix, Rest, List),  % разбиваем список
    append(Rest, Prefix, Result).
mainShift :- read_list(Input), shift_left_3(Input, Result), print_list(Result).

% 12. Дан целочисленный массив. Необходимо переставить в обратном порядке элементы массива, расположенные между его минимальным и максимальным элементами.
% Предикат для нахождения позиции минимального элемента
find_min_pos([X|Xs], Pos) :-
    find_min_pos(Xs, 1, 0, X, Pos).

find_min_pos([], _, Pos, _, Pos).
find_min_pos([X|Xs], CurrentPos, CurrentMinPos, CurrentMinVal, Pos) :-
    (X < CurrentMinVal ->
        NewMinPos = CurrentPos,
        NewMinVal = X
    ;
        NewMinPos = CurrentMinPos,
        NewMinVal = CurrentMinVal
    ),
    NextPos is CurrentPos + 1,
    find_min_pos(Xs, NextPos, NewMinPos, NewMinVal, Pos).

% Нахождение позиции максимального элемента (без значения)
find_max_pos([X|Xs], Pos) :-
    find_max_pos(Xs, 1, 0, X, Pos).

find_max_pos([], _, Pos, _, Pos).
find_max_pos([X|Xs], CurrentPos, CurrentMaxPos, CurrentMaxVal, Pos) :-
    (X > CurrentMaxVal ->
        NewMaxPos = CurrentPos,
        NewMaxVal = X
    ;
        NewMaxPos = CurrentMaxPos,
        NewMaxVal = CurrentMaxVal
    ),
    NextPos is CurrentPos + 1,
    find_max_pos(Xs, NextPos, NewMaxPos, NewMaxVal, Pos).

% Разделение списка на части
split_list(List, Start, End, Before, Middle, After) :-
    length(Before, Start),
    append(Before, Rest, List),
    MiddleLength is End - Start + 1,
    length(Middle, MiddleLength),
    append(Middle, After, Rest).

% Переворот части списка между min и max
reverse_between_min_max(List, Result) :-
    find_min_pos(List, MinPos),
    find_max_pos(List, MaxPos),
    (MinPos < MaxPos ->
        Start is MinPos + 1,
        End is MaxPos - 1
    ;
        Start is MaxPos + 1,
        End is MinPos - 1
    ),
    (Start =< End ->
        split_list(List, Start, End, Before, Middle, After),
        reverse(Middle, ReversedMiddle),
        append(Before, ReversedMiddle, Temp),
        append(Temp, After, Result)
    ;
        Result = List
    ).

mainReverse :- read_list(Input),  reverse_between_min_max(Input, Result),  print_list(Result).

% 13. Дан целочисленный массив. Необходимо найти элементы, расположенные перед первым минимальным.
elements_before_min([H|T], Result) :-
    min_index([H|T], 0, H, 0, MinIndex),
    sublist([H|T], 0, MinIndex, Result).

min_index([], _, _, Index, Index).
min_index([H|T], I, Min, MinI, Index) :-
    I1 is I + 1,
    ( H < Min -> min_index(T, I1, H, I, Index)
    ; min_index(T, I1, Min, MinI, Index) ).

sublist(_, End, End, []) :- !.
sublist([H|T], I, End, [H|Rest]) :-
    I < End,
    I1 is I + 1,
    sublist(T, I1, End, Rest).

mainElementsBeforeMin :- read_list(Input),  elements_before_min(Input, Result),  print_list(Result).

% задание 5
% Найти сумму непростых делителей числа.

read_number(N) :- write('Введите число: '), read(N).

% Делимость
divides(N, D) :- N mod D =:= 0.

% Есть делитель от D до sqrt(N)
has_divisor(N, D) :-
    D * D =< N,
    (N mod D =:= 0; D1 is D + 1, has_divisor(N, D1)).

% Простое число — не имеет делителей от 2 до sqrt(N)
is_prime(2).
is_prime(N) :- N > 2, \+ has_divisor(N, 2).

% Непростое число
is_not_prime(N) :- N < 2; (N > 2, has_divisor(N, 2)).

% Сумма непростых делителей
sum_nonprime_divisors(N, Sum) :- sum_nonprime_divisors(N, 1, 0, Sum).

sum_nonprime_divisors(N, D, Acc, Sum) :- D > N, !, Sum = Acc.

sum_nonprime_divisors(N, D, Acc, Sum) :-
    divides(N, D),
    is_not_prime(D),
    !,
    Acc1 is Acc + D,
    D1 is D + 1,
    sum_nonprime_divisors(N, D1, Acc1, Sum).

sum_nonprime_divisors(N, D, Acc, Sum) :-
    D1 is D + 1,
    sum_nonprime_divisors(N, D1, Acc, Sum).

mainNoprime :-
    read_number(N),
    sum_nonprime_divisors(N, Sum),
    print_list(Sum).

% Найти количество чисел, не являющихся делителями исходного числа, не взамнопростых с ним и взаимно простых с суммой простых цифр этого числа.

% НОД
gcd(A, 0, A) :- !.
gcd(A, B, Gcd) :-
    B > 0,
    R is A mod B,
    gcd(B, R, Gcd).

% Проверка, что числа взаимно простые
are_coprime(A, B) :- gcd(A, B, 1).

% Проверка, что числа не взаимно простые
are_not_coprime(A, B) :- gcd(A, B, Gcd), Gcd > 1.

% Сумма простых цифр числа
sum_prime_digits(N, Sum) :-
    number_chars(N, Chars),
    maplist(atom_number, Chars, Digits),
    include(is_prime, Digits, PrimeDigits),
    sum_list(PrimeDigits, Sum).

% Проверка всех условий для числа M
satisfies_conditions(N, M) :-
    \+ divides(N, M),            % M не делитель N
    are_not_coprime(N, M),       % M и N не взаимно простые
    sum_prime_digits(N, SumPD),   % Сумма простых цифр N
    are_coprime(M, SumPD).       % M и сумма простых цифр N взаимно простые

% Подсчет количества чисел, удовлетворяющих условиям
count_numbers(N, Count) :-
    findall(M, (between(1, N, M), satisfies_conditions(N, M)), Numbers),
    length(Numbers, Count).

mainNum :-
    read_number(N),
    count_numbers(N, Count),
    print_list(Count).
