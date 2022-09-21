import * as React from "react";
import IconButton from "@mui/material/IconButton";
import DeleteForeverIcon from "@mui/icons-material/DeleteForever";
import DeveloperService from "../../../api/DeveloperService";
import TableCell from "@mui/material/TableCell";
import TableRow from "@mui/material/TableRow";
import EditIcon from "@mui/icons-material/Edit";
import FormDialog from "../../Dialogs/FormDialog";
import PlatformService from "../../../api/PlatformService";
import EditPlatformForm from "../../Forms/EditForms/EditPlatformForm";

export default function PlatformRows(props) {
  const [open, setOpen] = React.useState(false);

  const handleDelete = () => {
    PlatformService.deletePlatform(props.platform.id).then((res) => {
      props.getPlatforms();
    });
  };

  const handleClickOpen = () => {
    setOpen(true);
  };

  return (
    <>
      <TableRow
        key={props.platform.id}
        sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
      >
        <TableCell allign="center">{props.platform.name}</TableCell>
        <TableCell align="center">
          <IconButton onClick={handleClickOpen} aria-label="comment">
            <EditIcon />
          </IconButton>
        </TableCell>
        <TableCell align="center">
          <IconButton onClick={handleDelete} aria-label="comment">
            <DeleteForeverIcon />
          </IconButton>
        </TableCell>
      </TableRow>
      <FormDialog
        id={props.platform.id}
        setOpen={setOpen}
        open={open}
        handleClickOpen={handleClickOpen}
        getGenres={props.getPlatforms}
        name={props.platform.name}
        form={EditPlatformForm}
      />
    </>
  );
}
