:- encoding(utf8).

% часть света
continent(usa, 1).              % Северная Америка
continent(france, 2).           % Европа
continent(japan, 3).            % Азия
continent(brazil, 4).           % Южная Америка
continent(india, 3).            % Азия
continent(canada, 1).           % Северная Америка
continent(egypt, 5).            % Африка
continent(australia, 6).        % Австралия
continent(uk, 2).               % Европа
continent(germany, 2).          % Европа
continent(mexico, 1).           % Северная Америка
continent(italy, 2).            % Европа
continent(china, 3).            % Азия
continent(belarus, 2).          % Европа
continent(south_africa, 5).     % Африка
continent(argentina, 4).        % Южная Америка
continent(spain, 2).            % Европа
continent(south_korea, 3).      % Азия
continent(sweden, 2).           % Европа

% язык
language(usa, 1).               % Английский
language(france, 2).            % Французский
language(japan, 3).             % Японский
language(brazil, 4).            % Португальский
language(india, 5).             % Хинди
language(canada, 1).            % Английский
language(egypt, 6).             % Арабский
language(australia, 1).         % Английский
language(uk, 1).                % Английский
language(germany, 2).           % Немецкий
language(mexico, 4).            % Испанский
language(italy, 2).             % Итальянский
language(china, 3).             % Китайский
language(belarus, 3).           % Белорусский
language(south_africa, 6).      % Африканс
language(argentina, 4).         % Испанский
language(spain, 4).             % Испанский
language(south_korea, 3).       % Корейский
language(sweden, 2).            % Шведский

% население
population(usa, 3).             % Большое
population(france, 2).          % Среднее
population(japan, 2).           % Среднее
population(brazil, 3).          % Большое
population(india, 4).           % Очень большое
population(canada, 1).          % Малое
population(egypt, 3).           % Большое
population(australia, 2).       % Среднее
population(uk, 3).              % Большое
population(germany, 3).         % Большое
population(mexico, 3).          % Большое
population(italy, 2).           % Среднее
population(china, 4).           % Очень большое
population(belarus, 2).         % Среднее
population(south_africa, 3).    % Большое
population(argentina, 3).       % Большое
population(spain, 3).           % Большое
population(south_korea, 2).     % Среднее
population(sweden, 1).          % Малое

% валюта
currency(usa, 1).               % Доллар
currency(france, 2).            % Евро
currency(japan, 3).             % Йена
currency(brazil, 4).            % Реал
currency(india, 5).             % Рупия
currency(canada, 1).            % Доллар
currency(egypt, 6).             % Фунт
currency(australia, 1).         % Доллар
currency(uk, 6).                % Фунт
currency(germany, 2).           % Евро
currency(mexico, 4).            % Песо
currency(italy, 2).             % Евро
currency(china, 3).             % Юань
currency(belarus, 1).           % Рубль
currency(south_africa, 6).      % Ранд
currency(argentina, 4).         % Аргентинское песо
currency(spain, 2).             % Евро
currency(south_korea, 3).       % Вон
currency(sweden, 2).            % Шведская крона

% климат
climate(usa, 1).                % Тропический
climate(france, 2).             % Умеренный
climate(japan, 3).              % Умеренный
climate(brazil, 1).             % Тропический
climate(india, 1).              % Тропический
climate(canada, 4).             % Арктический
climate(egypt, 1).              % Тропический
climate(australia, 2).          % Умеренный
climate(uk, 2).                 % Умеренный
climate(germany, 2).            % Умеренный
climate(mexico, 1).             % Тропический
climate(italy, 2).              % Умеренный
climate(china, 1).              % Тропический
climate(belarus, 3).            % Континентальный
climate(south_africa, 1).       % Тропический
climate(argentina, 2).          % Умеренный
climate(spain, 2).              % Умеренный
climate(south_korea, 2).        % Умеренный
climate(sweden, 4).             % Арктический

question1(X1):-	write("В какой части света находится ваша страна?"), nl,
                write("1. Северная Америка"), nl,
                write("2. Европа"), nl,
                write("3. Азия"), nl,
                write("4. Южная Америка"), nl,
                write("5. Африка"), nl,
                write("6. Австралия"), nl,
                read(X1).

question2(X2):-	write("Какой основной язык в вашей стране?"), nl,
                write("1. Английский"), nl,
                write("2. Французский"), nl,
                write("3. Японский"), nl,
                write("4. Португальский"), nl,
                write("5. Хинди"), nl,
                write("6. Арабский"), nl,
                read(X2).

question3(X3):-	write("Какое население в вашей стране?"), nl,
                write("1. Малое"), nl,
                write("2. Среднее"), nl,
                write("3. Большое"), nl,
                write("4. Очень большое"), nl,
                read(X3).

question4(X4):-	write("Какая валюта используется в вашей стране?"), nl,
                write("1. Доллар"), nl,
                write("2. Евро"), nl,
                write("3. Йена"), nl,
                write("4. Реал"), nl,
                write("5. Рупия"), nl,
                write("6. Фунт"), nl,
                read(X4).

question5(X5):-	write("Какой климат в вашей стране?"), nl,
                write("1. Тропический"), nl,
                write("2. Умеренный"), nl,
                write("3. Континентальный"), nl,
                write("4. Арктический"), nl,
                read(X5).

pr:-	question1(X1), question2(X2), question3(X3), question4(X4), question5(X5),
		continent(Country, X1), language(Country, X2), population(Country, X3), 
		currency(Country, X4), climate(Country, X5),
		write("Страна: "), write(Country), nl.
