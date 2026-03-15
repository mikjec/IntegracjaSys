<?php
$servername = "localhost";
$username = "sakila2";
$password = "pass";
$database = "sakila";

$conn = new mysqli($servername, $username, $password, $database);

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$id = rand(1, 200);

$sql = "DELETE FROM actor WHERE actor_id=$id";

$conn->query($sql);

echo "Actor deleted";

$conn->close();
