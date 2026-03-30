<?php
class Cities
{
    private $citiesTable = "city";
    public $id;
    public $name;
    public $countryCode;
    private $conn;

    public function __construct($db)
    {
        $this->conn = $db;
    }

    function read()
    {
        if ($this->id) {
            $stmt = $this->conn->prepare("SELECT * FROM " . $this->citiesTable . " WHERE ID = ?");
            $stmt->bind_param("i", $this->id);
        } else {
            $stmt = $this->conn->prepare("SELECT * FROM " . $this->citiesTable);
        }
        $stmt->execute();
        return $stmt->get_result();
    }


    function create()
    {
        $stmt = $this->conn->prepare(
            "INSERT INTO " . $this->citiesTable . " (Name, CountryCode) VALUES (?, ?)"
        );

        $stmt->bind_param("ss", $this->name, $this->countryCode);

        return $stmt->execute();
    }

    function update()
    {
        $stmt = $this->conn->prepare("UPDATE " . $this->citiesTable . " SET Name = ? WHERE ID = ?");
        $stmt->bind_param("si", $this->name, $this->id);

        if ($stmt->execute()) {
            return true;
        }
        return false;
    }

    function delete()
    {
        $stmt = $this->conn->prepare(
            "DELETE FROM " . $this->citiesTable . " WHERE ID = ?"
        );

        $stmt->bind_param("i", $this->id);

        return $stmt->execute();
    }
}
