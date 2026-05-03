<?php
$servername = "localhost";
$username = "sakila1";
$password = "pass";
$database = "sakila";
$conn = new mysqli($servername, $username, $password, $database);

echo "Database connected successfully.<br><br>";

$conn->begin_transaction();
$conn->query("UPDATE actor SET first_name = 'CHRIS' WHERE first_name = 'ADAM'");
echo "Zmieniono ADAM na CHRIS (niezatwierdzone!). Czekam 15 sekund...<br>";

// Czekamy, aby dać czas innemu skryptowi na "brudny odczyt"
sleep(15);

// Zamiast COMMIT, robimy ROLLBACK - wycofujemy wszystkie zmiany!
$conn->rollback();
echo "Wycofano zmiany (ROLLBACK)! Baza wrocila do stanu poczatkowego.";

$conn->close();
