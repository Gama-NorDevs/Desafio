import { Button, Step, StepLabel, Stepper } from "@material-ui/core";
import React, { useState } from "react";
import { useStyles } from "./style";

import "react-data-grid/dist/react-data-grid.css";
import StepContext from "./StepContext";

function ProductionAdd() {
  const classes = useStyles();
  const [activeStep, setActiveStep] = useState(0);

  function handleNext() {
    setActiveStep((prevActiveStep) => prevActiveStep + 1);
  }

  function handleBack() {
    setActiveStep((prevActiveStep) => prevActiveStep - 1);
  }

  return (
    <div className={classes.root}>
      <Stepper activeStep={activeStep} alternativeLabel>
        <Step>
          <StepLabel>Dados Basicos</StepLabel>
        </Step>
        <Step>
          <StepLabel>Elenco</StepLabel>
        </Step>
      </Stepper>
      <StepContext step={activeStep} classes={classes} />

      <div className={classes.button}>
        <Button
          variant="contained"
          disabled={activeStep === 0}
          onClick={handleBack}
        >
          Voltar
        </Button>
        <Button variant="contained" color="primary" onClick={handleNext}>
          {activeStep === 1 ? "Salvar" : "Montar elenco"}
        </Button>
      </div>
    </div>
  );
}
export default ProductionAdd;
