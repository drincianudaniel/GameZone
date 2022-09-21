import * as React from "react";
import { Box } from "@mui/system";
import { useState } from "react";
import { useEffect } from "react";
import GamePagination from "../Pagination/GamePagination";
import PlatformService from "../../api/PlatformService";
import PlatformRows from "../Tables/TableRows/PlatformsRow";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import LocalSearchBar from "../Search/LocalSearchBar";
import { Typography } from "@mui/material";

export default function Platforms() {
  const [platforms, setPlatforms] = useState([]);
  const [page, setPage] = useState(1);
  const [numberOfPages, setNumberOfPages] = useState(1);
  const [searchString, setSearchString] = useState("");

  useEffect(() => {
    getPlatforms();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [page]);

  const getPlatforms = () => {
    PlatformService.getPlatformsPaginated(page, searchString).then((res) => {
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
      <LocalSearchBar
        setSearchString={setSearchString}
        searchString={searchString}
        getData={getPlatforms}
      />
      {platforms.length > 0 ? (
        <TableContainer sx={{ maxWidth: 700, mb: 2 }}>
        <Table sx={{ maxWidth: 700 }} aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell sx={{ fontWeight: "bold" }} align="left">
                Name
              </TableCell>
              <TableCell sx={{ fontWeight: "bold" }} align="center">
                Edit
              </TableCell>
              <TableCell sx={{ fontWeight: "bold" }} align="center">
                Delete
              </TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {platforms.map((platform, i) => {
              return (
                <PlatformRows getPlatforms={getPlatforms} platform={platform} />
              );
            })}
          </TableBody>
        </Table>
      </TableContainer>
      ): <Typography sx={{ mt: 1 }}>No platforms found...</Typography>}
      

      <GamePagination setPage={setPage} numberOfPages={numberOfPages} />
    </Box>
  );
}
