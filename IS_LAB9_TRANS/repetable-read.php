<?php
// example of REPEATABLE READ transaction isolation level
$servername = "localhost";
$username = "sakila1";
$password = "pass";
$database = "sakila";
$conn = new mysqli(
    $servername,
    $username,
    $password,
    $database
);
if ($conn->connect_error) {
    die("Database connection failed: " . $conn->connect_error);
}
echo "Databse connected successfully, username " .
    $username . "<br><br>";

// Start transaction
$conn->begin_transaction();
echo "Before sleep<br>";
$sql = "SELECT actor_id, first_name, last_name FROM actor
WHERE first_name = 'ADAM'";
$result = $conn->query($sql);
if ($result->num_rows > 0) {
    // output data of each row
    while ($row = $result->fetch_assoc()) {
        echo "id: " . $row["actor_id"] . " - Name: " .
            $row["first_name"] . " " . $row["last_name"] . "<br>";
    }
} else {
    echo "0 results<br>";
}

// that the database state will be changes
sleep(20);

// this is due to the REPEATABLE READ level of isolation
echo "After sleep<br>";
$sql = "SELECT actor_id, first_name, last_name FROM actor
WHERE first_name = 'ADAM'";
$result = $conn->query($sql);
if ($result->num_rows > 0) {
    // output data of each row
    while ($row = $result->fetch_assoc()) {
        echo "id: " . $row["actor_id"] . " - Name: " .
            $row["first_name"] . " " . $row["last_name"] . "<br>";
    }
} else {
    echo "0 results<br>";
}
//End transaction
$conn->commit();
$conn->close();
