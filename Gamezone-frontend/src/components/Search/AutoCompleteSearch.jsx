import { Typography } from "@mui/material";
import * as React from "react";
import { useState } from "react";
import {
  AsyncPaginate,
  reduceGroupedOptions,
} from "react-select-async-paginate";
import SearchIcon from "@mui/icons-material/Search";
import { Box } from "@mui/system";
import UserService from "../../api/UserService";
import GameService from "../../api/GameService";
import axios from "axios";

function AutoCompleteSearch(props) {
  const [value] = useState(null);

  const handleSearch = (searchGame) => {
    props.handleSearchGame(searchGame);
  };

  const loadOptions = async (searchString, callback) => {
    if (searchString.length > 1) {
      const games = GameService.GamesAutoComplete(searchString);
      const users = UserService.UsersAutoComplete(searchString);

      const data = axios.all([games, users]).then(
        axios.spread((...responses) => {
          return {
            options: responses[0].data
              .concat(responses[1].data)
              .map((element) => {
                return {
                  value: element.id,
                  label: element.name,
                  type: element.type,
                };
              }),
          };
        })
      );

      const mapTypeToIndex = new Map();
      const result = [];
      return new Promise(function (resolve, reject) {
        data
          .then((res) => {
            console.log(res.options);
            res.options.forEach((option) => {
              const { type } = option;

              if (mapTypeToIndex.has(type)) {
                const index = mapTypeToIndex.get(type);

                result[index].options.push(option);
              } else {
                const index = result.length;

                mapTypeToIndex.set(type, index);

                result.push({
                  label: `${type}`,
                  options: [option],
                });
              }
            });
            resolve({ options: result });
          })
          .catch((err) => reject(err));
      });
    } else {
      callback(null);
    }
  };
  return (
    <AsyncPaginate
      placeholder={
        <Box sx={{ display: "flex" }}>
          <SearchIcon fontSize="small"></SearchIcon>
          <Typography>Search</Typography>
        </Box>
      }
      debounceTimeout={600}
      onChange={handleSearch}
      value={value}
      loadOptions={loadOptions}
      reduceOptions={reduceGroupedOptions}
      className="searchbar"
      style={{ padding: "0px" }}
    />
  );
}
export default AutoCompleteSearch;
