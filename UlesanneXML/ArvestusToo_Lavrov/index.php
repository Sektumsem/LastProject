<?php
$dataXML=simplexml_load_file("Menuu.xml");

$getToit= $dataXML-> menuu-> toid->toit;
$getJook= $dataXML-> menuu-> joogid->jook;


function searchToitByNimi($query){
    global $dataXML;
    $result=array();
    foreach($dataXML -> menuu->toid->toit as $toid){
        if(substr(strtolower($toid),0,strlen($query)) == strtolower($query))
            array_push($result, $toid);
    }
    return $result;
}

?>


<!DOCTYPE HTML>
<html lang="et">

    <head>
        <title style="color:White;">Tallinna restoran</title>
        <meta charset="utf8">
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">

    </head>
    <body>
        <header>
            <h1 align="center" style="color:White;">Tallinna restorani menüü</h1>
        </header>

        <style>
            body {
                background-image: url('bg.jpg');
                background-repeat: no-repeat;
                background-attachment: fixed;
                background-size: 100% 100%;
            }
        </style>

<main>

    <div class="container">
        <?php
        echo"<table border='1' style=\"width:50%;float:left\"  class=\"table table-hover table-dark\">";
        echo"<tr>";
        echo"<th>Toidud</th>";
        echo"</tr>";
        foreach($dataXML->menuu->toid->toit as $menuu){
            echo"<tr>";
            echo"<td>".$menuu." ".$menuu->attributes()->hind."</td>";

            echo"</tr>";
        }
        echo"</table>";

        echo"<table border='1' style=\"width:50%;float:left\"  class=\"table table-hover table-dark\">";
        echo"<tr>";
        echo"<th>Joogid</th>";
        echo"</tr>";
        foreach($dataXML->menuu->joogid->jook as $menuu){
            echo"<tr>";
            echo"<td>".$menuu." ".$menuu->attributes()->hind."</td>";
            echo"</tr>";
        }
        echo"</table>";

        echo"<br>";
        echo"<h3 style=\"color:White;\">Tellimusse staatus</h3>";
        echo"<br>";

        echo "<table border='1'  style=\"width:100%;float:left\"  class=\"table table-hover table-dark\">";
        echo "<tr>";
        echo "<th>Tellimuse number</th>";
        echo "<th>Laud</th>";
        echo "<th>Jook</th>";
        echo "<th>Toit</th>";
        echo "<th>Teenindaja</th>";
        echo "<th>Tellimuse stastus</th>";
        echo "</tr>";
        foreach ($dataXML->tellimus as $tellimus) {
            echo "<tr>";
            echo "<td>$tellimus->number</td>";
            echo "<td>$tellimus->laud</td>";
            echo "<td>".$getJook[(int)$tellimus->joogid-1]."</td>";
            echo "<td>".$getToit[(int)$tellimus->toid-1]."</td>";
            echo "<td>$tellimus->tenindaja</td>";
            echo "<td>$tellimus->tellimusestaatus</td>";
            echo "</tr>";
        }
        echo "</table>";
        echo"<br>";
        ?>


        <br>
        <form action="?" method="post">
            <br>
            <p style="color:White;">Otsi toid:</p>
            <input type="text" name="search" placeholder="Nimetus" />
            <input type="submit" value="Find" />
        </form>
        <?php
        echo"<br>";
        if(!empty ($_POST["search"])) {
            $result = searchToitByNimi($_POST["search"]);
            echo "<table border='1' style=\"width:50%;float:left\"  class=\"table table-hover table-dark\">";
            echo "<tr>";
            echo "<th>Toidud</th>";
            echo "</tr>";
            foreach ($result as $toid) {
                echo "<tr>";
                echo"<td>".$toid." ".$toid->attributes()->hind."</td>";
                echo "</tr>";
            }
            echo "</table>";
        }
        ?>
    </div>
</main>
    </body>
</html>