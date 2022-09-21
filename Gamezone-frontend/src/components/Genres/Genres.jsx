import * as React from "react";
import List from "@mui/material/List";
import { Box } from "@mui/system";
import { useState } from "react";
import { useEffect } from "react";
import GamePagination from "../Pagination/GamePagination";
import GenreService from "../../api/GenreService";
import GenresRow from "../Tables/TableRows/GenresRow";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import LocalSearchBar from "../Search/LocalSearchBar";

export default function Genres() {
  const [genres, setGenres] = useState([]);
  const [page, setPage] = useState(1);
  const [numberOfPages, setNumberOfPages] = useState(1);
  const [searchString, setSearchString] = useState("");

  useEffect(() => {
    getGenres();
  }, [page]);

  const getGenres = () => {
    GenreService.getGenresPaginated(page, searchString).then((res) => {
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
      <LocalSearchBar setSearchString={setSearchString} searchString={searchString} getData={getGenres} />
      <TableContainer sx={{ maxWidth: 700 }}>
        <Table sx={{ maxWidth: 700 }} aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell sx={{ fontWeight: "bold" }} align="left">
                Name
              </TableCell>
              <TableCell sx={{ fontWeight: "bold" }} align="right">
                Edit
              </TableCell>
              <TableCell sx={{ fontWeight: "bold" }} align="right">
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
