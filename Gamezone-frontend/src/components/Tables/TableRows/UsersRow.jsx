import * as React from "react";
import IconButton from "@mui/material/IconButton";
import DeleteForeverIcon from "@mui/icons-material/DeleteForever";
import TableCell from "@mui/material/TableCell";
import TableRow from "@mui/material/TableRow";
import UserService from "../../../api/UserService";
import { useState, useEffect } from "react";
import { Typography } from "@mui/material";

export default function UsersRow(props) {

  const [roles, setRoles] = useState([]);

  useEffect(() =>{
    console.log(props.user.roles)
    setRoles(props.user.roles);
  }, [roles])

  const handleDelete = () => {
    UserService.DeleteUser(props.user.user.id).then((res) => {
      props.getUsers();
    });
  };

  return (
    <>
      <TableRow
        key={props.user.user.id}
        sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
      >
        <TableCell allign="center">{props.user.user.userName}</TableCell>
        <TableCell allign="center">{roles.map(role=>{
          return <Typography sx={{display:"inline"}}>{role} </Typography> 
        })}</TableCell>
        <TableCell align="right">
          <IconButton onClick={handleDelete} aria-label="comment">
            <DeleteForeverIcon sx={{color: "primary.main"}} />
          </IconButton>
        </TableCell>
      </TableRow>
    </>
  );
}
