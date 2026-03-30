<?php
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json");
header("Access-Control-Allow-Methods: DELETE");

include_once '../config/Database.php';
include_once '../class/Cities.php';

$database = new Database();
$db = $database->getConnection();

$cities = new Cities($db);

$data = json_decode(file_get_contents("php://input"));


$cities->id = $data->id;

if ($cities->delete()) {
    echo json_encode(array("message" => "City deleted"));
} else {
    http_response_code(503);
    echo json_encode(array("message" => "Unable to delete"));
}
