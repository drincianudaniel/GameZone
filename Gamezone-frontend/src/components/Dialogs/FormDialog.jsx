import * as React from "react";
import Button from "@mui/material/Button";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogContentText from "@mui/material/DialogContentText";
import DialogTitle from "@mui/material/DialogTitle";
import EditDeveloperForm from "../Forms/EditForms/EditDeveloperForm";

export default function FormDialog(props) {
  const handleClose = () => {
    props.setOpen(false);
  };

  return (
    <div>
      <Dialog open={props.open} onClose={handleClose}>
        <DialogTitle>Edit</DialogTitle>
        <DialogContent>
          <EditDeveloperForm
            name={props.name}
            headquarters={props.headquarters}
            id={props.id}
            handleClose={handleClose}
            getDevelopers={props.getDevelopers}
          />
          <Button onClick={handleClose}>Cancel</Button>
        </DialogContent>
      </Dialog>
    </div>
  );
}
