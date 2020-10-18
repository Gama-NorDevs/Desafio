import {
  FormControl,
  Grid,
  InputLabel,
  MenuItem,
  Paper,
  Select,
  TextField,
} from "@material-ui/core";
import React, { useCallback, useMemo, useState } from "react";
import ReactDataGrid, { SelectColumn } from "react-data-grid";

function StepContext({ step, classes }) {
  const [selectedRows, setSelectedRows] = useState(() => new Set());
  const [[sortColumn, sortDirection], setSort] = useState(["status", "NONE"]);
  const [filter, setFilters] = useState({
    status: "",
    filterValues: ["Livre", "Ocupado"],
  });

  const [rows, setRows] = useState([
    { id: 0, name: "Teste", amount: 20, status: "Livre" },
    { id: 1, name: "Teste1", amount: 40, status: "Ocupado" },
    { id: 2, name: "Teste2", amount: 60, status: "Livre" },
    { id: 3, name: "Teste3", amount: 100, status: "Livre" },
  ]);

  const columns = [
    SelectColumn,
    { key: "name", name: "Nome" },
    {
      key: "status",
      name: "Status",
      summaryFormatter() {
        return <strong>Total</strong>;
      },
    },
    {
      key: "amount",
      name: "Valor",
      summaryFormatter({ row }) {
        return <> {row.totalSelect}</>;
      },
    },
  ];

  const summaryRows = useMemo(() => {
    const summaryRow = {
      id: "total_0",
      totalSelect: rows.reduce((prev, current) => {
        if (selectedRows.has(current.id)) {
          console.log(current);
          return prev + current.amount;
        }
        return prev;
      }, 0),
    };
    return [summaryRow];
  }, [rows, selectedRows]);

  const sortRows = useMemo(() => {
    if (sortDirection === "NONE") return rows;

    let sortedRows;
    if (filter.status === "") {
      sortedRows = [...rows];
    } else {
      sortedRows = rows.filter((row) => filter.status === row.status);
    }

    //  = [...rows];

    switch (sortColumn) {
      case "amount":
        sortedRows = sortedRows.sort((a, b) => a[sortColumn] - b[sortColumn]);
        break;
      default:
        sortedRows = sortedRows.sort((a, b) =>
          a[sortColumn].localeCompare(b[sortColumn])
        );
    }

    return sortDirection === "ASC" ? sortedRows : sortedRows.reverse();
  }, [filter, rows, sortColumn, sortDirection]);

  const handleSort = useCallback((columnKey, direction) => {
    setSort([columnKey, direction]);
  }, []);

  switch (step) {
    case 0:
      return (
        <Paper className={classes.paper} elevation={3} component={"form"}>
          <Grid container spacing={2}>
            <Grid item xs={12}>
              <TextField required label="Nome" variant="outlined" fullWidth />
            </Grid>
            <Grid item xs={6} sm={4}>
              <TextField
                required
                label="Quantidade de Atores"
                type="number"
                variant="outlined"
                fullWidth
              />
            </Grid>
            <Grid item xs={6} sm={4}>
              <FormControl required variant="outlined" fullWidth>
                <InputLabel id="select-genero">Genero</InputLabel>
                <Select labelId="select-genero" label="Genero">
                  <MenuItem value={""}>{""}</MenuItem>
                  <MenuItem value={"Terror"}>Terror</MenuItem>
                  <MenuItem value={"Comedia"}>Comedia</MenuItem>
                </Select>
              </FormControl>
            </Grid>
            <Grid item xs={12} sm={4}>
              <TextField
                required
                label="Orçamento"
                type="number"
                variant="outlined"
                fullWidth
              />
            </Grid>
            <Grid item xs={6}>
              <TextField
                id="date"
                label="Inicio"
                type="date"
                variant="outlined"
                fullWidth
                InputLabelProps={{
                  shrink: true,
                }}
                inputProps={{
                  min: new Date()
                    .toLocaleDateString()

                    .split("/")
                    .reverse()
                    .join("-"),
                }}
              />
            </Grid>
            <Grid item xs={6}>
              <TextField
                label="Fim"
                type="date"
                variant="outlined"
                fullWidth
                InputLabelProps={{
                  shrink: true,
                }}
              />
            </Grid>
          </Grid>
          {/* <Button
            className={classes.button}
            variant="contained"
            color="primary"
            fullWidth
            >
            Buscar
          </Button> */}
        </Paper>
      );
    case 1:
      return (
        <>
          <FormControl required variant="outlined" fullWidth>
            <InputLabel id="select-status">Status</InputLabel>
            <Select
              labelId="select-status"
              label="Status"
              defaultValue={""}
              onChange={(e) =>
                setFilters((prev) => ({ ...prev, status: e.target.value }))
              }
            >
              <MenuItem value={""}>Todos</MenuItem>
              {filter.filterValues.map((item) => (
                <MenuItem value={item} key={item}>
                  {item}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
          <ReactDataGrid
            rowKey="id"
            columns={columns}
            rows={sortRows}
            selectedRows={selectedRows}
            onSelectedRowsChange={setSelectedRows}
            defaultColumnOptions={{
              sortable: true,
              resizable: true,
            }}
            summaryRows={summaryRows}
            sortColumn={sortColumn}
            sortDirection={sortDirection}
            onSort={handleSort}
          />
        </>
      );
    default:
      return <></>;
  }
}

export default StepContext;
