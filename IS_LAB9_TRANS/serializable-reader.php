<?php
$servername = "localhost";
$username = "sakila1";
$password = "pass";
$database = "sakila";
$conn = new mysqli($servername, $username, $password, $database);

$conn->query("SET SESSION TRANSACTION ISOLATION LEVEL SERIALIZABLE");
$conn->begin_transaction();

echo "Odczyt nr 1:<br>";
$result = $conn->query("SELECT actor_id, first_name, last_name FROM actor WHERE first_name = 'ADAM'");
while ($row = $result->fetch_assoc()) echo "id: " . $row["actor_id"] . " - Name: " . $row["first_name"] . " " . $row["last_name"] . "<br>";

sleep(15);

echo "<br>Odczyt nr 2:<br>";
$result = $conn->query("SELECT actor_id, first_name, last_name FROM actor WHERE first_name = 'ADAM'");
while ($row = $result->fetch_assoc()) echo "id: " . $row["actor_id"] . " - Name: " . $row["first_name"] . " " . $row["last_name"] . "<br>";

$conn->commit();
$conn->close();
