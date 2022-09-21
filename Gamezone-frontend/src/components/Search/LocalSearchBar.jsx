import * as React from "react";
import Paper from "@mui/material/Paper";
import InputBase from "@mui/material/InputBase";
import Divider from "@mui/material/Divider";
import IconButton from "@mui/material/IconButton";
import MenuIcon from "@mui/icons-material/Menu";
import SearchIcon from "@mui/icons-material/Search";
import DirectionsIcon from "@mui/icons-material/Directions";

export default function LocalSearchBar(props) {

    const handleSearch = () => {
        props.getData();
      };

  return (
    <Paper
      component="form"
      sx={{ p: "2px 4px", display: "flex", alignItems: "center", maxWidth: 400 }}
    >
      <InputBase
        sx={{ ml: 1, flex: 1 }}
        onKeyPress={e => e.key === 'Enter' && e.preventDefault()}
        placeholder="Search"
        value={props.searchString}
        onInput={e=> props.setSearchString(e.target.value)}
      />
      <IconButton
        onClick={handleSearch}
        type="button"
        sx={{ p: "10px" }}
        aria-label="search"
      >
        <SearchIcon />
      </IconButton>
    </Paper>
  );
}
