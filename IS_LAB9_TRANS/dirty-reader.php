<?php
$servername = "localhost";
$username = "sakila1";
$password = "pass";
$database = "sakila";
$conn = new mysqli($servername, $username, $password, $database);

$conn->query("SET SESSION TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
$conn->begin_transaction();

echo "Odczyt 1:<br>";
$result = $conn->query("SELECT actor_id, first_name FROM actor WHERE first_name = 'ADAM'");
if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) echo "id: " . $row["actor_id"] . " - Name: " . $row["first_name"] . "<br>";
} else {
    echo "0 results<br>";
}


sleep(5);

echo "Odczyt 2<br>";
$result = $conn->query("SELECT actor_id, first_name FROM actor WHERE first_name = 'ADAM'");
if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) echo "id: " . $row["actor_id"] . " - Name: " . $row["first_name"] . "<br>";
} else {
    echo "0 results<br>";
}

sleep(15);

echo "Odczyt 3:<br>";
$result = $conn->query("SELECT actor_id, first_name FROM actor WHERE first_name = 'ADAM'");
if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) echo "id: " . $row["actor_id"] . " - Name: " . $row["first_name"] . "<br>";
} else {
    echo "0 results<br>";
}

$conn->commit();
$conn->close();
