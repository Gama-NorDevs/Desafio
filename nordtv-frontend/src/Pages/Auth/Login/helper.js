import * as Yup from "yup";

export const initialValues = {
  login: "",
  password: "",
};

export const validationSchema = Yup.object().shape({
  login: Yup.string().email().required("Esse campo é obrigatorio"),
  password: Yup.string().required("Esse campo é obrigatorio"),
});
