import * as React from "react";
import { Box } from "@mui/system";
import DeveloperService from "../../api/DeveloperService";
import DevelopersList from "../Tables/TableRows/DevelopersRow";
import { useState } from "react";
import { useEffect } from "react";
import GamePagination from "../Pagination/GamePagination";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell, { tableCellClasses } from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import DevelopersRow from "../Tables/TableRows/DevelopersRow";

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
      <TableContainer sx={{ maxWidth: 700 }}>
        <Table sx={{ maxWidth: 700}} aria-label="simple table">
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
