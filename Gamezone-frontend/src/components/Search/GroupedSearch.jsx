import { Typography } from "@mui/material";
import * as React from "react";
import { useState } from "react";
import { AsyncPaginate } from "react-select-async-paginate";
import SearchIcon from "@mui/icons-material/Search";
import { Box } from "@mui/system";
import GameService from "../../api/GameService";
import UserService from "../../api/UserService";
import { useEffect } from "react";

function GroupedSearch(props) {
  const [games, setGames] = useState([]);
  const [users, setUsers] = useState([]);

  const [groupedOptions, setGroupedOptions] = useState([
    {
      label: "Games",
      options: games,
    },
    {
      label: "Users",
      options: users,
    },
  ]);

  useEffect(()=>{
    getData();
  })

  const getData = async () => {
    await GameService.getGames().then((res) => {
      setGames(res.data);
      console.log(games)
    });

    await UserService.GetUsers().then((res) => {
      setUsers(res.data);
    });

    console.log(groupedOptions)
  };



  const filterOption = ({ label, value }, string) => {
    // default search
    if (label.includes(string) || value.includes(string)) return true;

    // check if a group as the filter string as label
    const groupOptions = groupedOptions.filter((group) =>
      group.label.toLocaleLowerCase().includes(string)
    );

    if (groupOptions) {
      for (const groupOption of groupOptions) {
        // Check if current option is in group
        const option = groupOption.options.find((opt) => opt.value === value);
        if (option) {
          return true;
        }
      }
    }
    return false;
  };

  return (
    <>awsdasdasdasd</>
  );
}
export default GroupedSearch;
