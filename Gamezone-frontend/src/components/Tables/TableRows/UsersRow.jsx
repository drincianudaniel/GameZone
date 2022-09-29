import * as React from "react";
import IconButton from "@mui/material/IconButton";
import DeleteForeverIcon from "@mui/icons-material/DeleteForever";
import TableCell from "@mui/material/TableCell";
import TableRow from "@mui/material/TableRow";
import UserService from "../../../api/UserService";

export default function UsersRow(props) {

  const handleDelete = () => {
    UserService.DeleteUser(props.user.id).then((res) => {
      props.getUsers();
    });
  };

  return (
    <>
      <TableRow
        key={props.user.id}
        sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
      >
        <TableCell allign="center">{props.user.userName}</TableCell>
        <TableCell align="right">
          <IconButton onClick={handleDelete} aria-label="comment">
            <DeleteForeverIcon sx={{color: "primary.main"}} />
          </IconButton>
        </TableCell>
      </TableRow>
    </>
  );
}
