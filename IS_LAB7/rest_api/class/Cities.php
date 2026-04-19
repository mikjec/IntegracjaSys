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
            $query = "SELECT c.ID, c.Name, c.District, c.Population, c.CountryCode, co.Name AS CountryName FROM " . $this->citiesTable . " c LEFT JOIN country co ON c.CountryCode = co.Code WHERE c.ID = ?";

            $stmt = $this->conn->prepare($query);
            $stmt->bind_param("i", $this->id);
        } else {
            $query = "SELECT c.ID, c.Name, c.District, c.Population, c.CountryCode, co.Name AS CountryName FROM " . $this->citiesTable . " c LEFT JOIN country co ON c.CountryCode = co.Code";

            $stmt = $this->conn->prepare($query);
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
        $stmt->execute();

        if ($stmt->affected_rows > 0) {
            return true;
        }

        return false;
    }
}
