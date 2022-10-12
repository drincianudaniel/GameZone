import * as React from "react";
import IconButton from "@mui/material/IconButton";
import DeleteForeverIcon from "@mui/icons-material/DeleteForever";
import TableCell from "@mui/material/TableCell";
import TableRow from "@mui/material/TableRow";
import EditIcon from "@mui/icons-material/Edit";
import FormDialog from "../../Dialogs/FormDialog";
import GenreService from "../../../api/GenreService";
import EditGenreForm from "../../Forms/EditForms/EditGenreForm";

export default function GenresRow(props) {
  const [open, setOpen] = React.useState(false);

  const handleDelete = () => {
    GenreService.deleteGenre(props.genre.id).then((res) => {
      props.getGenres();
    });
  };

  const handleClickOpen = () => {
    setOpen(true);
  };

  return (
    <>
      <TableRow
        key={props.genre.id}
        sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
      >
        <TableCell allign="center">{props.genre.name}</TableCell>
        <TableCell align="right">
          <IconButton onClick={handleClickOpen} aria-label="comment">
            <EditIcon sx={{ color: "primary.main" }} />
          </IconButton>
        </TableCell>
        <TableCell align="right">
          <IconButton onClick={handleDelete} aria-label="comment">
            <DeleteForeverIcon sx={{ color: "primary.main" }} />
          </IconButton>
        </TableCell>
      </TableRow>
      <FormDialog
        id={props.genre.id}
        setOpen={setOpen}
        open={open}
        handleClickOpen={handleClickOpen}
        getGenres={props.getGenres}
        name={props.genre.name}
        form={EditGenreForm}
      />
    </>
  );
}
