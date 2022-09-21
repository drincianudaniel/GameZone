import { Typography } from "@mui/material";
import * as React from "react";
import { useState } from "react";
import { AsyncPaginate } from "react-select-async-paginate";
import SearchIcon from "@mui/icons-material/Search";
import { Box } from "@mui/system";

function AutoCompleteSearch(props) {
  const [game, setGame] = useState();

  const handleSearch = (searchGame) => {
    setGame(searchGame);
    props.handleSearchGame(searchGame);
  };

  const loadOptions = async (gameSearched, callback) => {
    if (gameSearched.length > 1) {
      const data = fetch(
        `${process.env.REACT_APP_SERVERIP}/games/auto-complete/${gameSearched}`
      )
        .then((res) => res.json())
        .then((res) => {
          return {
            options: res.map((element) => {
              return {
                value: element.id,
                label: element.name,
              };
            }),
          };
        })
        .catch((err) => console.log(err));
      return data;
    } else {
      callback(null);
    }
  };
  return (
    <AsyncPaginate
      placeholder={
        <Box sx={{display:"flex"}}>
          <SearchIcon fontSize="small"></SearchIcon>
          <Typography>Search</Typography>
        </Box>
      }
      value={game}
      debounceTimeout={600}
      onChange={handleSearch}
      loadOptions={loadOptions}
      className="searchbar"
      style={{ padding: "0px" }}
    />
  );
}
export default AutoCompleteSearch;
