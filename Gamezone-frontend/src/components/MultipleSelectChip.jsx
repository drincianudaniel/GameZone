import * as React from "react";
import { useEffect, useState } from "react";
import { useTheme } from "@mui/material/styles";
import Box from "@mui/material/Box";
import OutlinedInput from "@mui/material/OutlinedInput";
import InputLabel from "@mui/material/InputLabel";
import MenuItem from "@mui/material/MenuItem";
import FormControl from "@mui/material/FormControl";
import Select from "@mui/material/Select";
import Chip from "@mui/material/Chip";

const ITEM_HEIGHT = 48;
const ITEM_PADDING_TOP = 8;
const MenuProps = {
  PaperProps: {
    style: {
      maxHeight: ITEM_HEIGHT * 4.5 + ITEM_PADDING_TOP,
      width: 250,
    },
  },
};

function getStyles(name, personName, theme) {
  return {
    fontWeight:
      personName.indexOf(name) === -1
        ? theme.typography.fontWeightRegular
        : theme.typography.fontWeightMedium,
  };
}

export default function MultipleSelectChip(props) {
  const theme = useTheme();
  const [data, setData] = useState([]);
  const [personName, setPersonName] = useState([]);
  const [dataToSend, setDataToSend] = useState([]);
  useEffect(() => {
    getData()
  }, []);

  const getData = () =>{
    props.getData().then(res => setData(res))
  }  

  const handleChange = (event) => {
    const {
      target: { value },
    } = event;
    setPersonName(typeof value.id === "string" ? value.split(",") : value);
    setDataToSend(dataToSend => [...dataToSend, value])
  };

  return (
    <div>
      <FormControl sx={{ m: 1, width: 300 }}>
        <InputLabel id="demo-multiple-chip-label">{props.name}</InputLabel>
        <Select
          labelId="demo-multiple-chip-label"
          id="demo-multiple-chip"
          multiple
          value={personName}
          onChange={handleChange}
          input={<OutlinedInput id="select-multiple-chip" label="Chip" />}
          renderValue={(selected) => (
            <Box sx={{ display: "flex", flexWrap: "wrap", gap: 0.5 }}>
              {selected.map((value) => (
                <Chip key={value.id} label={value.name} />
              ))}
            </Box>
          )}
          MenuProps={MenuProps}
        >
          {data.map((val) => (
            <MenuItem
              key={val.id}
              value={val}
              style={getStyles(val.name, personName, theme)}
            >
              {val.name}
            </MenuItem>
          ))}
        </Select>
      </FormControl>
      {console.log(dataToSend)}
    </div>
  );
}
