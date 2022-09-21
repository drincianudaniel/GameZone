import * as React from "react";
import { Box } from "@mui/system";
import DeveloperService from "../../api/DeveloperService";
import { useState } from "react";
import { useEffect } from "react";
import GamePagination from "../Pagination/GamePagination";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import DevelopersRow from "../Tables/TableRows/DevelopersRow";
import LocalSearchBar from "../Search/LocalSearchBar";

export default function Developers() {
  const [developers, setDevelopers] = useState([]);
  const [page, setPage] = useState(1);
  const [numberOfPages, setNumberOfPages] = useState(1);
  const [searchString, setSearchString] = useState("");

  useEffect(() => {
    getDevelopers();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [page]);

  const getDevelopers = () => {
    DeveloperService.getDevelopersPaginated(page, searchString).then((res) => {
      setDevelopers(res.data.data);
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
        getData={getDevelopers}
      />
      <TableContainer sx={{ maxWidth: 700, mb: 2 }}>
        <Table sx={{ maxWidth: 700 }} aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell sx={{ fontWeight: "bold" }} align="left">
                Name
              </TableCell>
              <TableCell sx={{ fontWeight: "bold" }} align="left">
                Headquarters
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
            {developers.map((developer, i) => {
              return (
                <DevelopersRow
                  getDevelopers={getDevelopers}
                  developer={developer}
                />
              );
            })}
          </TableBody>
        </Table>
      </TableContainer>

      <GamePagination setPage={setPage} numberOfPages={numberOfPages} />
    </Box>
  );
}
