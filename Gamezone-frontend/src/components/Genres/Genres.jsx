import * as React from "react";
import List from "@mui/material/List";
import { Box } from "@mui/system";
import { useState } from "react";
import { useEffect } from "react";
import GamePagination from "../Pagination/GamePagination";
import GenreService from "../../api/GenreService";
import GenresList from "../Lists/GenresList";
import GenresRow from "../Tables/TableRows/GenresRow";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell, { tableCellClasses } from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";

export default function Genres() {
  const [genres, setGenres] = useState([]);
  const [page, setPage] = useState(1);
  const [numberOfPages, setNumberOfPages] = useState(1);

  useEffect(() => {
    getGenres();
  }, [page]);

  const getGenres = () => {
    GenreService.getGenresPaginated(page).then((res) => {
      setGenres(res.data.data);
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
            {genres.map((genre, i) => {
              return <GenresRow getGenres={getGenres} genre={genre} />;
            })}
          </TableBody>
        </Table>
      </TableContainer>
      <GamePagination setPage={setPage} numberOfPages={numberOfPages} />
    </Box>
  );
}
