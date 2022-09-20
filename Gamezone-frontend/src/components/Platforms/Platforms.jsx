import * as React from "react";
import List from "@mui/material/List";
import { Box } from "@mui/system";
import { useState } from "react";
import { useEffect } from "react";
import GamePagination from "../Pagination/GamePagination";
import PlatformService from "../../api/PlatformService";
import PlatformsList from "../Lists/PlatformsList";

export default function Platforms() {
  const [platforms, setPlatforms] = useState([]);
  const [page, setPage] = useState(1);
  const [numberOfPages, setNumberOfPages] = useState(1);

  useEffect(() => {
    getPlatforms();
  }, [page]);

  const getPlatforms = () => {
    PlatformService.getPlatformsPaginated(page).then((res) => {
      setPlatforms(res.data.data);
      setNumberOfPages(res.data.totalPages);
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
        {platforms.map((platform, i) => {
          return <PlatformsList getPlatforms={getPlatforms} platform={platform} />;
        })}
      </List>

      <GamePagination setPage={setPage} numberOfPages={numberOfPages} />
    </Box>
  );
}
