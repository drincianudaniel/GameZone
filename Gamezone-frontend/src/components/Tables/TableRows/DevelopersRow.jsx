import * as React from "react";
import IconButton from "@mui/material/IconButton";
import DeleteForeverIcon from "@mui/icons-material/DeleteForever";
import DeveloperService from "../../../api/DeveloperService";
import TableCell from "@mui/material/TableCell";
import TableRow from "@mui/material/TableRow";
import EditIcon from "@mui/icons-material/Edit";
import FormDialog from "../../Dialogs/FormDialog";
import EditDeveloperForm from "../../Forms/EditForms/EditDeveloperForm";

export default function DevelopersRow(props) {

  const [open, setOpen] = React.useState(false);

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleDelete = () => {
    DeveloperService.deleteDeveloper(props.developer.id).then((res) => {
      props.getDevelopers();
    });
  };

  return (
    <>
      <TableRow
        key={props.developer.id}
        sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
      >
        <TableCell allign="center">{props.developer.name}</TableCell>
        <TableCell align="left">{props.developer.headquarters}</TableCell>
        <TableCell align="center">
          <IconButton onClick={handleClickOpen} aria-label="comment">
            <EditIcon sx={{color: "primary.main"}}/>
          </IconButton>
        </TableCell>
        <TableCell align="center">
          <IconButton onClick={handleDelete} aria-label="comment">
            <DeleteForeverIcon sx={{color: "primary.main"}} />
          </IconButton>
        </TableCell>
      </TableRow>
      <FormDialog
        id = {props.developer.id}
        setOpen={setOpen}
        open={open}
        handleClickOpen={handleClickOpen}
        getDevelopers={props.getDevelopers}
        name = {props.developer.name}
        headquarters = {props.developer.headquarters}
        form ={EditDeveloperForm}
      />
    </>
  );
}
