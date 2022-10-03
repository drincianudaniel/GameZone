import * as React from "react";
import IconButton from "@mui/material/IconButton";
import DeleteForeverIcon from "@mui/icons-material/DeleteForever";
import TableCell from "@mui/material/TableCell";
import TableRow from "@mui/material/TableRow";
import UserService from "../../../api/UserService";
import { useState, useEffect } from "react";
import { Typography } from "@mui/material";
import CheckIcon from "@mui/icons-material/Check";
import ClearIcon from "@mui/icons-material/Clear";
import { toast } from "react-toastify";

export default function UsersRow(props) {
  const [roles, setRoles] = useState([]);
  const [isAdmin, setIsAdmin] = useState(false);
  useEffect(() => {
    isAdminCheck();
    setRoles(props.user.roles);
  }, [roles]);

  const handleDelete = () => {
    UserService.DeleteUser(props.user.user.id).then((res) => {
      props.getUsers();
    });
  };

  const addAdmin = () => {
    UserService.AddRoleToUser(props.user.user.userName, "Admin").then((res) => {
      props.getUsers();
      setIsAdmin(true);
      toast.success(res.data);
    });
  };

  const removeAdmin = () => {
    UserService.RemoveRoleFromUser(props.user.user.userName, "Admin").then(
      (res) => {
        props.getUsers();
        setIsAdmin(false);
        toast.success(res.data);
      }
    );
  };

  const isAdminCheck = () => {
    roles.map((role) => {
      if (role === "Admin") {
        setIsAdmin(true);
      }
    });
  };

  return (
    <>
      <TableRow
        key={props.user.user.id}
        sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
      >
        <TableCell allign="center">{props.user.user.userName}</TableCell>
        <TableCell allign="center">
          {roles.map((role) => {
            return <Typography sx={{ display: "inline" }}>{role} </Typography>;
          })}
        </TableCell>
        {!isAdmin && (
          <TableCell align="right">
            <IconButton onClick={addAdmin} aria-label="comment">
              <CheckIcon sx={{ color: "primary.main" }} />
            </IconButton>
          </TableCell>
        )}
        {isAdmin && (
          <TableCell onClick={removeAdmin} align="right">
            <IconButton aria-label="comment">
              <ClearIcon sx={{ color: "primary.main" }} />
            </IconButton>
          </TableCell>
        )}
        <TableCell align="right">
          <IconButton onClick={handleDelete} aria-label="comment">
            <DeleteForeverIcon sx={{ color: "primary.main" }} />
          </IconButton>
        </TableCell>
      </TableRow>
    </>
  );
}
