import yaml
from deserialize_json import DeserializeJson
from serialize_json import SerializeJson
from convert_json_to_yaml import ConvertJsonToYaml

print("hey, it's me - Python!")

tempconffile = open('Assets/basic_config.yaml', encoding="utf8")
confdata = yaml.load(tempconffile, Loader=yaml.FullLoader)
tempconffile.close()

json_src_file = confdata['paths']['source_folder'] + confdata['paths']['json_source_file']
json_dest_file = confdata['paths']['source_folder'] + confdata['paths']['json_destination_file']
yaml_dest_file = confdata['paths']['source_folder'] + confdata['paths']['yaml_destination_file']

data_source = None

if confdata['source']['type'] == 'object':
    data_source = DeserializeJson(json_src_file)
else:
    data_source = json_src_file

def run_stats():
    if isinstance(data_source, DeserializeJson):
        data_source.somestats()
    else:
        print("Statystyki można liczyć tylko na obiekcie DeserializeJson")

def run_serialize_json():
    if isinstance(data_source, DeserializeJson):
        SerializeJson.run(data_source, json_dest_file)
    else:
        print("Serializacja JSON możliwa tylko na obiekcie DeserializeJson")

def run_convert_yaml():
    ConvertJsonToYaml.run(data_source, yaml_dest_file)
operations_map = {
    "stats": run_stats,
    "serialize_json": run_serialize_json,
    "convert_yaml": run_convert_yaml
}

for op_name in confdata['operations']:
    if op_name in operations_map:
        operations_map[op_name]()