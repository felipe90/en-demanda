library(readxl)
library(ran)
library(ggplot2)
library(caret)
set.seed(137)

data = read_xlsx("../oscar/Drive_OR/1-DATA/Hackatrix_2019/Datos/Desplazados_2018_octubre_01_6a.xlsx")

df = data

df$d_ano = NULL
df$subsi = NULL
df$d_nomsec = NULL
df$dane_ant = NULL
df$d_nombinst = NULL
df$d_sede = NULL
df$d_nombsede = NULL
df$sector = NULL
df$tipo_vul = NULL
df$metodo = NULL
df$d_nomjor = NULL
df$d_edad = NULL
df$d_hombres = NULL
df$d_mujeres = NULL

nombres = c("Mun", "Num_Mun", "R-U", "Grado", "Gen", "Situ", "Edad", "Etnia", "Disc",
            "Cocina", "Pintura", "Aseo", "Ropa", "Jardineria", "ID", "Rating")

df$a = sample(1:0, length(row.names(df)), replace = TRUE)
df$b = sample(1:0, length(row.names(df)), replace = TRUE)
df$c = sample(1:0, length(row.names(df)), replace = TRUE)
df$e = sample(1:0, length(row.names(df)), replace = TRUE)
df$f = sample(1:0, length(row.names(df)), replace = TRUE)
df$g = sample(70:100, length(row.names(df)), replace = TRUE)
df$ID = seq(5000:10326)

colnames(df) = nombres

write.table(df, "../oscar/Drive_OR/1-DATA/Hackatrix_2019/Datos/db_3.txt")
write.csv(df, "../oscar/Drive_OR/1-DATA/Hackatrix_2019/Datos/db_3.csv")

df_ed = as.data.frame(table(df$Edad))

ggplot(df_ed, aes(x = df_ed$Var1, y = df_ed$Freq)) +
  geom_col() +
  ggtitle("Aspirantes registrados en la base de datos") +
  labs(x = "Edad Aspirante" , y = "Cantidad Aspirantes")

ggplot(df, (aes(x = df$Num_Mun))) +
  geom_bar() +
  ggtitle("Municipios fuente de desplazamiento0") +
  coord_flip() +
  labs(x = NULL, y = "Cantidad")

ggplot(df, aes(x = df$`R-U`)) +
  geom_bar(aes(fill = df$Gen)) +
  labs(x = NULL, y = NULL) +
  ggtitle("Distribución Candidatos Rural/Urbano")

ggplot(df, aes(x = df$Edad, y = df$Etnia)) +
  geom_count(aes(color = df$Gen), alpha = 0.5) +
  ggtitle("Distribución etnia, edad, sexo") +
  labs(x = "Edad", y = "Etnia")

# Archivo .dat modelo
rating = read.table("../oscar/Drive_OR/1-DATA/Hackatrix_2019/Datos/ml-1m/ratings.dat", fileEncoding="latin1")

train_rating = createDataPartition(rating$V4, p = 0.8, list = FALSE)
test_rating = rating[rating != train_rating,]


write.csv(rating, "../oscar/Drive_OR/1-DATA/Hackatrix_2019/Datos/train_rating.csv")
write.csv(rating, "../oscar/Drive_OR/1-DATA/Hackatrix_2019/Datos/test_rating.csv")

p = df[df$Disc != "NO TIENE DISCAPACIDAD",]
  
ggplot(p, aes(x = p$Disc)) +
  geom_bar(aes(fill = p$Gen)) +
  coord_flip() +
  labs(y = "Cantidad", x = "Discapacidad") +
  ggtitle("Personas en condición de discapacidad 2.8% del total de la población")
  
ggplot(df, aes(x = df$Situ)) +
  geom_bar(aes(fill = df$Gen)) +
  coord_flip() +
  ggtitle("Situación de las aspirantes") +
  labs(x = NULL, y = NULL)



