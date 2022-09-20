import * as React from "react";
import List from "@mui/material/List";
import { Box } from "@mui/system";
import { useState } from "react";
import { useEffect } from "react";
import GamePagination from "../Pagination/GamePagination";
import GenreService from "../../api/GenreService";
import GenresList from "../Lists/GenresList";

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
      <List sx={{ width: "100%", maxWidth: 500, bgcolor: "background.paper" }}>
        {genres.map((genre, i) => {
          return <GenresList getGenres={getGenres} genre={genre} />;
        })}
      </List>

      <GamePagination setPage={setPage} numberOfPages={numberOfPages} />
    </Box>
  );
}
