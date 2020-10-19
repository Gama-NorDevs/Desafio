import * as Yup from "yup";

export const initialValues = {
  name: "",
  email: "",
  amount: "",
  sex: "",
  password: "",
  profile: "ACTOR",
};

export const validationSchema = Yup.object().shape({
  name: Yup.string().required("Esse campo é obrigatorio"),
  email: Yup.string().email().required("Esse campo é obrigatorio"),
  amount: Yup.number().positive().required("Esse campo é obrigatorio"),
  sex: Yup.string().required("Esse campo é obrigatorio"),
  password: Yup.string().required("Esse campo é obrigatorio"),
});
