import * as React from "react";
import List from "@mui/material/List";
import { Box } from "@mui/system";
import DeveloperService from "../../api/DeveloperService";
import DevelopersList from "../Lists/DevelopersList";
import { useState } from "react";
import { useEffect } from "react";
import GamePagination from "../Pagination/GamePagination";

export default function Developers() {
  const [developers, setDevelopers] = useState([]);
  const [page, setPage] = useState(1);
  const [numberOfPages, setNumberOfPages] = useState(1);

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
