% задание 4. акинатор
high(ruby,1).
high(c_sharp,1).
high(python,1).
high(c_plu_plus,1).
high(f_sharp,1).
high(prolog,1).
high(c, 1).
high(asm,0).
high(haskell,1).
high(java,1).
high(kotlin,1).

decl(ruby,0).
decl(c_sharp,0).
decl(python,0).
decl(c_plu_plus,0).
decl(f_sharp,1).
decl(prolog,1).
decl(c,0).
decl(asm,0).
decl(haskell, 1).
decl(java, 0).
decl(kotlin, 0).

interpret(ruby,1).
interpret(python,1).
interpret(f_sharp,1).
interpret(prolog,1).
interpret(c_sharp,0).
interpret(c_plu_plus,0).
interpret(c,0).
interpret(asm,0).
interpret(haskell, 1).
interpret(java, 1).
interpret(kotlin, 1).

oop(ruby,3).
oop(c_sharp,3).
oop(python,2).
oop(c_plu_plus,2).
oop(f_sharp,1).
oop(prolog,1).
oop(c,0).
oop(asm,0).
oop(haskell, 0).
oop(java, 3).
oop(kotlin, 3).

cross(ruby,1).
cross(python,1).
cross(c_plu_plus,1).
cross(prolog,1).
cross(c,1).
cross(asm,1).
cross(c_sharp,0).
cross(f_sharp,0).
cross(haskell, 1).
cross(java, 1).
cross(kotlin, 1).

visual(c_sharp,3).
visual(ruby,2).
visual(python,2).
visual(c_plu_plus,2).
visual(f_sharp,2).
visual(prolog,1).
visual(c,0).
visual(asm,0).
visual(haskell, 1).
visual(java, 2).
visual(kotlin, 2).

mobile(c_sharp,0).
mobile(ruby,0).
mobile(python,0).
mobile(c_plu_plus,0).
mobile(f_sharp,0).
mobile(prolog,0).
mobile(c,0).
mobile(asm,0).
mobile(haskell, 0).
mobile(java, 1).
mobile(kotlin, 1).

% Новые факты к новому вопросу
semicolon(c_sharp, 1).
semicolon(ruby, 0).
semicolon(python, 0).
semicolon(c_plu_plus, 1).
semicolon(f_sharp, 0).
semicolon(prolog, 0).
semicolon(c, 1).
semicolon(asm, 1).
semicolon(java, 1).
semicolon(kotlin, 0).
semicolon(haskell, 0).

question1(X1):-	write("Is your language high level?"),nl,
				write("1. Yes"),nl,
				write("0. NO"),nl,
				read(X1).

question2(X2):-	write("Is your language declarative?"),nl,
				write("1. Yes"),nl,
				write("0. NO"),nl,
				read(X2).

question3(X3):-	write("Is your language interpret?"),nl,
				write("1. Yes"),nl,
				write("0. NO"),nl,
				read(X3).

question4(X4):-	write("Does your language support OOP?"),nl,
				write("3. It is OOP itself"),nl,
				write("2. yes"),nl,
				write("1. yes, but very hard"),nl,
				write("0. NO"),nl,
				read(X4).

question5(X5):-	write("Is your language crossplatformic?"),nl,
				write("1. Yes"),nl,
				write("0. NO"),nl,
				read(X5).

question6(X6):-	write("Does your language support visual interface for user?"),nl,
				write("3. It is visual itself"),nl,
				write("2. yes"),nl,
				write("1. yes, but very hard"),nl,
				write("0. NO"),nl,
				read(X6).

question7(X7):-	write("Is your language for mobile phones?"),nl,
				write("1. Yes"),nl,
				write("0. NO"),nl,
				read(X7).				

% Новый вопрос
question8(X8):- 
                write("Does your language require semicolons at the end of each statement?"), nl,
                write("1. Yes"), nl,
                write("0. No"), nl,
                read(X8).

pr:-	question1(X1),question2(X2),question3(X3),question4(X4),
		question5(X5),question6(X6),question7(X7),
		high(X,X1),decl(X,X2),interpret(X,X3),oop(X,X4),
		cross(X,X5),visual(X,X6),mobile(X,X7),
		write(X).