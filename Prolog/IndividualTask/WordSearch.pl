:- encoding(utf8).
write_words_to_file(N, K) :-
    valid_params(N, K),
    Alphabet = [a,b,c,d,e,f],
    findall(Word, generate_word(N, K, Alphabet, Word), Words),
    sort(Words, UniqueWords),
    length(UniqueWords, Count),
    format('Количество сгенерированных уникальных слов: ~w~n', [Count]),
    open('words.txt', write, Stream),
    maplist(write_word(Stream), UniqueWords),
    close(Stream).

valid_params(N, K) :- N >= 5 + K.

% Случай K = 0 или 1
generate_word(N, K, Alphabet, Word) :-
    (K =:= 0 ; K =:= 1),
    member(L1, Alphabet),
    select(L1, Alphabet, AlphRest),
    repeat_list(L1, 5, Part1),
    LengthRest is N - 5,
    select_n(AlphRest, LengthRest, Rest),
    append(Part1, Rest, All),
    my_permutation(All, Perm),
    list_to_atom(Perm, Word).

% Случай K > 1
generate_word(N, K, Alphabet, Word) :-
    K > 1,
    member(L1, Alphabet),
    select(L1, Alphabet, Alph1),
    member(L2, Alph1),
    select(L2, Alph1, Alph2),
    repeat_list(L1, 5, Part1),
    repeat_list(L2, K, Part2),
    LengthRest is N - 5 - K,
    select_n(Alph2, LengthRest, Rest),
    append(Part1, Part2, Temp),
    append(Temp, Rest, All),
    my_permutation(All, Perm),
    list_to_atom(Perm, Word).

% Генерация списка с повторами
repeat_list(_, 0, []) :- !.
repeat_list(X, N, [X|Xs]) :-
    N1 is N - 1,
    repeat_list(X, N1, Xs).

% Выбор N элементов (комбинации) без повторений
select_n(_, 0, []) :- !.
select_n([H|T], N, [H|R]) :-
    N1 is N - 1,
    select_n(T, N1, R).
select_n([_|T], N, R) :-
    N > 0,
    select_n(T, N, R).

write_word(Stream, Word) :- format(Stream, "~w~n", [Word]).

% Генерация перестановки
my_permutation([], []).
my_permutation(List, [Elem|Perm]) :-
    select(Elem, List, Rest),
    my_permutation(Rest, Perm).

% Преобразование списка символов в атом
list_to_atom(CharList, Atom) :-
    chars_to_codes(CharList, Codes),
    atom_codes(Atom, Codes).

chars_to_codes([], []).
chars_to_codes([Char|Chars], [Code|Codes]) :-
    char_code(Char, Code),
    chars_to_codes(Chars, Codes).
