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
