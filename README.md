<h1>Документация по первому заданию</h1>
<br>
<h2><a href="https://lavrov17.thkit.ee/ArvestusToo_Lavrov/">Готовый проект PHP<a></h2>
<br>
<h3>Задание</h3>
<br>
Создать XML файл в который будет 2 или 3 логичиских диапазона
<br>
Файл должен содержать следующие поля :
  <li>Restoran</li>
  <li>Menüü</li>
  <li>Toit</li>
  <li>Jook</li>
  <li>Laud</li>
  <li>Tenindaja</li>
  <li>Tellimus</li>
  <li>Tellimusestaatus</li>
<br>
Сделать вывод таблицы на HTML с использованием:
PHP
<br>
Функции:
Поиск по названию блюда
<br>
  <h2>XML файл</h2>
<code>
<?xml version="1.0" encoding="utf-8" ?>
<restaran>
    <menuu>
        <toid>
            <toit id="1" hind="18.00€">Glasuuritud veise sisefilee punase veini kastmes</toit>
            <toit id="2" hind="15.00€">Madalküpsetatud talleliha lisanditega</toit>
            <toit id="3" hind="14.00€">Lihaveise piprane antrekoot, steakhouse kartulitega</toit>
            <toit id="4" hind="14.00€">Küpsetatud pardifilee  lisanditega </toit>
            <toit id="5" hind="13.00€">Kala peakoka valikul</toit>
            <toit id="6" hind="12.00€">Praetud lõhe grillitud köögiviljade, seente ja anšoovise võiga</toit>
            <toit id="7" hind="8.00€">Sinimerekarbid valge veini kastmega</toit>
            <toit id="8" hind="5.00€">Kreemine seenesupp</toit>
            <toit id="9" hind="8.00€">Vürtsikas kookosesupp mereandidega</toit>
            <toit id="10" hind="5.00€">Creme brulee Baileys</toit>
        </toid>
        <joogid>
            <jook id="1" hind="1.50€">Cola</jook>
            <jook id="2" hind="1.50€">Fanta</jook>
            <jook id="3" hind="1.50€">Sprite</jook>
            <jook id="4" hind="1.50€">Cola Zero</jook>
            <jook id="5" hind="1.20€">Tomati mahl</jook>
            <jook id="6" hind="1.20€">Apelsini mahl</jook>
            <jook id="7" hind="1.80€">Tee</jook>
            <jook id="8" hind="2.00€">Kohv</jook>
            <jook id="9" hind="0.50€">Vesi</jook>
            <jook id="10" hind="1.20€">Multi mahl</jook>
        </joogid>
    </menuu>

    <tellimus id="1">
        <number>23234</number>
        <laud>3</laud>
        <toid>4</toid>
        <joogid>8</joogid>
        <tenindaja>Kirill</tenindaja>
        <tellimusestaatus>Valmis</tellimusestaatus>
    </tellimus>
    <tellimus id="2">
        <number>36257</number>
        <laud>6</laud>
        <toid>9</toid>
        <joogid>10</joogid>
        <tenindaja>Daniil</tenindaja>
        <tellimusestaatus>Ei ole valmis</tellimusestaatus>
    </tellimus>
</restaran>
</code>
