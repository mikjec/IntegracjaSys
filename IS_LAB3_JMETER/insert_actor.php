<?php
$servername = "localhost";
$username = "sakila2";
$password = "pass";
$database = "sakila";

$conn = new mysqli($servername, $username, $password, $database);

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$fname = "NAME" . rand(1, 10000);
$lname = "SURNAME" . rand(1, 10000);

$sql = "INSERT INTO actor (first_name,last_name,last_update)
VALUES ('$fname','$lname',NOW())";

$conn->query($sql);

echo "Actor inserted";

$conn->close();
