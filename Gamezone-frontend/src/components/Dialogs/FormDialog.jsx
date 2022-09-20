import * as React from "react";
import Button from "@mui/material/Button";
import Dialog from "@mui/material/Dialog";
import DialogContent from "@mui/material/DialogContent";
import DialogTitle from "@mui/material/DialogTitle";
import EditDeveloperForm from "../Forms/EditForms/EditDeveloperForm";

export default function FormDialog(props) {
  const handleClose = () => {
    props.setOpen(false);
  };

  const FormComponent = props.form
  return (
    <div>
      <Dialog open={props.open} onClose={handleClose}>
        <DialogTitle>Edit</DialogTitle>
        <DialogContent>
          <FormComponent {...props} handleClose={handleClose}/>
          <Button onClick={handleClose}>Cancel</Button>
        </DialogContent>
      </Dialog>
    </div>
  );
}
