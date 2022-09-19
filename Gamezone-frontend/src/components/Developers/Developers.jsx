import * as React from "react";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemText from "@mui/material/ListItemText";
import IconButton from "@mui/material/IconButton";
import EditIcon from "@mui/icons-material/Edit";
import DeleteForeverIcon from "@mui/icons-material/DeleteForever";
import { Box } from "@mui/system";
import DeveloperService from "../../api/DeveloperService";
import { set } from "date-fns";
import DevelopersList from "../Lists/DevelopersList";
import { useState } from "react";
import { useEffect } from "react";
import GamePagination from "../Pagination/GamePagination";

export default function Developers() {
  const [developers, setDevelopers] = useState([]);
  const [page, setPage] = useState(1);
  const [numberOfPages, setNumberOfPages] = useState(10);

  useEffect(() => {
    getDevelopers();
  }, [page]);

  const getDevelopers = () => {
    DeveloperService.getDevelopersPaginated(page).then((res) => {
      setDevelopers(res.data.data);
      setNumberOfPages(res.data.totalPages)
    });
  };

  return (
    <Box
      sx={{ width: "100%" }}
      display="flex"
      justifyContent="center"
      alignItems="center"
      flexDirection="column"
    >
      <List sx={{ width: "100%", maxWidth: 500, bgcolor: "background.paper" }}>
        {developers.map((developer, i) => {
          return (
            <DevelopersList
              getDevelopers={getDevelopers}
              developer={developer}
            />
          );
        })}
      </List>

      <GamePagination setPage={setPage} numberOfPages={numberOfPages} />

    </Box>
  );
}
