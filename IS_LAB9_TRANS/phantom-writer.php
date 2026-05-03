<?php
$servername = "localhost";
$username = "sakila1";
$password = "pass";
$database = "sakila";
$conn = new mysqli($servername, $username, $password, $database);

$sql = "INSERT INTO actor (first_name, last_name) VALUES ('ADAM', 'NOWAK_WIDMO')";
if ($conn->query($sql) === TRUE) {
    echo "Dodano nowego aktora: ADAM NOWAK_WIDMO";
} else {
    echo "Error: " . $conn->error;
}
$conn->close();
