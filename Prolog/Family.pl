man(voeneg).
man(ratibor).
man(boguslav).
man(velerad).
man(duhovlad).
man(svyatoslav).
man(dobrozhir).
man(bogomil).
man(zlatomir).

woman(goluba).
woman(lubomila).
woman(bratislava).
woman(veslava).
woman(zhdana).
woman(bozhedara).
woman(broneslava).
woman(veselina).
woman(zdislava).

parent(voeneg,ratibor).
parent(voeneg,bratislava).
parent(voeneg,velerad).
parent(voeneg,zhdana).

parent(goluba,ratibor).
parent(goluba,bratislava).
parent(goluba,velerad).
parent(goluba,zhdana).

parent(ratibor,svyatoslav).
parent(ratibor,dobrozhir).
parent(lubomila,svyatoslav).
parent(lubomila,dobrozhir).

parent(boguslav,bogomil).
parent(boguslav,bozhedara).
parent(bratislava,bogomil).
parent(bratislava,bozhedara).

parent(velerad,broneslava).
parent(velerad,veselina).
parent(veslava,broneslava).
parent(veslava,veselina).

parent(duhovlad,zdislava).
parent(duhovlad,zlatomir).
parent(zhdana,zdislava).
parent(zhdana,zlatomir).


% задание 1
man:- man(X), print(X), nl, fail.

% Построить предикат children(X), который выводит всех детей X.
children(X):- parent(X,Y), print(Y), nl, fail.

% Построить предикат mother(X, Y), который проверяет, является ли X матерью Y. Построить предикат, mother(X), который выводит маму X.
mother(X, Y):- parent(X,Y), woman(X).
mother(X):- mother(Y,X), print(Y).

% Построить предикат brother(X, Y), который проверяет, является ли X братом Y. Построить предикат brothers(X), который выводит всех братьев X.
brother(X,Y):- parent(Z,X), parent(Z,Y), man(X), X\=Y.
brothers(X) :-
    setof(Y, brother(Y,X), Broth),
    forall(member(B, Broth),(write(B), nl)).

% Построить предикат b_s(X,Y), который проверяет, являются ли X и Y родными братом и сестрой или братьями или сестрами. Построить предикат b_s(X), который выводит всех братьев или сестер X.
b_s(X,Y):- parent(Z,X), parent(Z,Y), X\=Y.
b_s(X) :-
    setof(Y, b_s(X,Y), Siblings),
    forall(member(S, Siblings), (write(S), nl)).

% задание 2 вариант 6
% Построить предикат daughter(X, Y), который проверяет, является ли X дочерью Y. Построить предикат, daughter(X), который выводит дочь X.
daughter(X, Y):- parent(Y, X), woman(X). 
daughter(X):- daughter(Y, X), print(Y), nl, fail.

% Построить предикат husband(X, Y), который проверяет, является ли X мужем Y. Построить предикат husband(X), который выводит мужа X.
husband(X, Y):- parent(X, Z), parent(Y, Z), man(X), !.
husband(X):- husband(Y, X), print(Y).

% задание 3 вариант 6
% Построить предикат grand_ma(X, Y), который проверяет, является ли X бабушкой Y. Построить предикат grand_mas(X), который выводит всех бабушек X.
grand_ma(X, Y):- parent(X, Z), parent(Z, Y), woman(X).
grand_mas(X):- grand_ma(Y, X), print(Y), nl, fail.

% Построить предикат grand_ma_and_da(X,Y), который проверяет, являются ли X и Y бабушкой и внучкой или внучкой и бабушкой.
grand_ma_and_da(X, Y):- (grand_ma(X, Y), woman(Y)); (grand_ma(Y, X), woman(X)), !.

% Построить предикат, который проверяет, является ли X тетей Y. Построить предикат, который выводит всех тетей X.
aunt(X, Y):- parent(Z, Y), b_s(X, Z), woman(X).
aunts(X) :-
    setof(Y, aunt(Y, X), Aunts),
    forall(member(A, Aunts), (write(A), nl)).