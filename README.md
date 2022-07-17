Экзаменационное задание по курсу "Разработка Windows-приложений на С#"

Приложение предназначено для расчета земляных работ при проектировании кабельных линий.

Для работы с Приложением в MS SQL Server создается база данных CableLines и в ней Таблица траншей dbo.Excavation.
Таблица траншей состоит из 6 столбцов:
-  Trenchid – ID траншеи;
- TrenchType – тип траншеи;
- TrenchDepth – глубина траншеи, м;
- TrenchWidth – ширина траншеи по дну, м;
- SandFilling – толщина слоя подсыпки песка, м;
- SandBackFilling – толщина слоя засыпки песком, м.

Для Плиложения определены следующие роли:
Администратор преимущественно работает с базой данных (непосредственно в ней) и осуществляет следующие действия:
-	создает базу данных и таблицы в ней;
-	осуществляет заполнение таблиц параметрами применяемых объектов, видами работ, изделиями и материалами;
-	осуществляет проверку данных, замену, корректировку и удаление данных из базы.
Работа с Приложением у Администратора сводится к следующим действиям:
-	выполняет настройку путем привязки к базе данных через установление имени сервера (в программном коде);
-	может осуществлять просмотр и сортировку данных в Таблице траншей на экране Приложения;
Пользователь осуществляет следующие действия:
-	На основании плана прокладки кабельных линий создает ведомость траншей.
-	Имеет возможность вручную вносить новые типы траншей Таблицу траншей в базе данных.
-	Удаление каких-либо данных из таблиц базы данных недоступно.
Требования к дальнейшему увеличению функционала
В дальнейшем планируется увеличение функционала Приложения:
- Приложение должно осуществлять проверку одинаковости количества кабелей на одном участке при различных условиях прокладки (в траншее или в трубе).
- Приложение должно иметь проверку на уникальность типов траншей при заполнении Таблицы траншей.
- планируется усовершенствовать Приложение до возможности полного расчета всех работ и материалов при проектировании кабельной линии, включающих в себя и другие элементы, представленные на разрезах траншей, такие как кабели, бетонные плиты, сигнальная лента, трубы и другие с одновременным автоматическим заполнением документов “Спецификация” и “Ведомость объемов работ”.
- планируется нарастить количество используемых таблиц базы данных, например, важными перспективными таблицами будут “Работы”, “Материалы” и “Изделия”.

Прилагаемые материалы.
1.	Скрипт для создания базы данных и таблицы траншей.
2.	Скрипт для заполнения таблицы траншей.
