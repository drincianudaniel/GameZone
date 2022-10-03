import * as React from "react";
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
import { Typography } from "@mui/material";
import UserService from "../../api/UserService";
import UsersRow from "../Tables/TableRows/UsersRow";

export default function Users() {
  const [users, setUsers] = useState([]);
  const [page, setPage] = useState(1);
  const [numberOfPages, setNumberOfPages] = useState(1);
  const [searchString, setSearchString] = useState("");

  useEffect(() => {
    getUsers();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [page]);

  const getUsers = () => {
    UserService.getGenresPaginated(page, searchString).then((res) => {
      setUsers(res.data.data);
      setNumberOfPages(res.data.totalPages);
    });
  };

  return (
    <Box
      sx={{ width: "100%", mt:2 }}
      display="flex"
      justifyContent="center"
      alignItems="center"
      flexDirection="column"
    >
      <LocalSearchBar
        setSearchString={setSearchString}
        searchString={searchString}
        getData={getUsers}
      />
      {users.length > 0 ? (
        <TableContainer sx={{ maxWidth: 700, mb: 2 }}>
          <Table sx={{ maxWidth: 700 }} aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell sx={{ fontWeight: "bold" }} align="left">
                  UserName
                </TableCell>
                <TableCell sx={{ fontWeight: "bold" }} align="left">
                  Roles
                </TableCell>
                <TableCell sx={{ fontWeight: "bold" }} align="right">
                  Delete
                </TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {users.map((user, i) => {
                return <UsersRow getUsers={getUsers} user={user} />;
              })}
            </TableBody>
          </Table>
        </TableContainer>
      ) : (
        <Typography sx={{ mt: 1 }}>No users found...</Typography>
      )}
      <GamePagination setPage={setPage} numberOfPages={numberOfPages} />
    </Box>
  );
}
