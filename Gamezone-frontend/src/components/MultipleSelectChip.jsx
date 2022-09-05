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

function getStyles(name, valueName, theme) {
  return {
    fontWeight:
      valueName.indexOf(name) === -1
        ? theme.typography.fontWeightRegular
        : theme.typography.fontWeightMedium,
  };
}

export default function MultipleSelectChip(props) {
  const theme = useTheme();
  const [data, setData] = useState([]);
  
  useEffect(() => {
    getData()
  }, []);

  const getData = () =>{
    props.getData().then(res => setData(res))
  }  

  return (
    <div>
      <FormControl sx={{ m: 1, width: 500 }}>
        <InputLabel id="demo-multiple-chip-label">{props.name}</InputLabel>
        <Select
          labelId="demo-multiple-chip-label"
          id="demo-multiple-chip"
          multiple
          value={props.valueName}
          onChange={props.handleChange}
          input={<OutlinedInput id="select-multiple-chip" label={props.name} />}
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
              style={getStyles(val.name, props.valueName, theme)}
            >
              {val.name}
            </MenuItem>
          ))}
        </Select>
      </FormControl>
    </div>
  );
}
