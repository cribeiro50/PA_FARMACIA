-- Criação da base de dados
-- Script BD para Gestão de Farmácias para o Trabalho de PA
-- Autores:
-- André Silva
-- Carlos Ribeiro
-- Duarte Valente
-- Rubem Brito
-- Rui Azevedo

CREATE DATABASE PA_GESTAO_FARMACIAS;
GO

USE PA_GESTAO_FARMACIAS;
GO

-- Tabela Farmacia
CREATE TABLE Farmacia (
    FarmaciaID INT PRIMARY KEY,
    NomeFarmacia NVARCHAR(100) NOT NULL,
    Endereco NVARCHAR(200)
);
GO

-- Tabela Funcionario
CREATE TABLE Funcionario (
    FuncionarioID INT PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100)
);
GO

-- Tabela Medicamento
CREATE TABLE Medicamento (
    MedicamentoID INT PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
    Fabricante NVARCHAR(100),
    Preco DECIMAL(10, 2) NOT NULL,
    Quantidade INT NOT NULL,
    FarmaciaID INT,
    FOREIGN KEY (FarmaciaID) REFERENCES Farmacia(FarmaciaID)
);
GO

-- Tabela Venda
CREATE TABLE Venda (
    VendaID INT PRIMARY KEY,
    DataVenda DATETIME NOT NULL,
    FarmaciaID INT,
    FuncionarioID INT,
    Total DECIMAL(10, 2),
    FOREIGN KEY (FarmaciaID) REFERENCES Farmacia(FarmaciaID),
    FOREIGN KEY (FuncionarioID) REFERENCES Funcionario(FuncionarioID)
);
GO

-- ################################################################### INSERT DE DADOS ###################################################################
-- Inserir Farmácias
INSERT INTO Farmacia (FarmaciaID, NomeFarmacia, Endereco)
VALUES 
(1, 'Farmácia São João', 'Rua A, 123'),
(2, 'Farmácia Pague Menos', 'Rua B, 456'),
(3, 'Farmácia Drogasil', 'Rua C, 789');
GO

-- Inserir Funcionários
INSERT INTO Funcionario (FuncionarioID, Nome, Email)
VALUES 
(1, 'Carlos Oliveira',  'carlos@farmacia.com'),
(2, 'Ana Costa',  'ana@farmacia.com'),
(3, 'Mariana Lima', 'mariana@farmacia.com');
GO

-- Inserir Medicamentos
INSERT INTO Medicamento (MedicamentoID, Nome, Fabricante, Preco, Quantidade, FarmaciaID)
VALUES 
(1, 'Paracetamol 500mg', 'Farmaco', 5.99, 100, 1),
(2, 'Ibuprofeno 200mg', 'MedicLab', 8.50, 50, 1),
(3, 'Amoxicilina 500mg', 'AntibioPharma', 12.30, 70, 2),
(4, 'Dipirona 1g', 'SaudeMais', 4.75, 200, 2),
(5, 'Omeprazol 20mg', 'GastroPharma', 15.00, 80, 3),
(6, 'Losartana 50mg', 'CardioLab', 18.90, 60, 3),
(7, 'Sinvastatina 20mg', 'ColesterolFree', 22.50, 40, 1),
(8, 'Cetirizina 10mg', 'AntiAlerg', 10.20, 30, 2),
(9, 'Metformina 850mg', 'DiabeteCare', 19.99, 90, 3),
(10, 'Clonazepam 2mg', 'Psiquiatrico', 30.00, 20, 1);
GO

-- Inserir Vendas
INSERT INTO Venda (VendaID, FarmaciaID, FuncionarioID, Total, DataVenda)
VALUES
(1, 1, 1, 11.98, '2024-12-01'),
(2, 1, 1, 30.00, '2024-12-02'),
(3, 1, 3, 8.50, '2024-12-02'),
(4, 1, 2, 22.50, '2024-12-03'),
(5, 1, 1, 5.99, '2024-12-04'),
(6, 2, 2, 12.30, '2024-12-01'),
(7, 2, 2, 9.50, '2024-12-01'),
(8, 2, 3, 4.75, '2024-12-02'),
(9, 2, 1, 10.20, '2024-12-02'),
(10, 2, 3, 30.00, '2024-12-03'),
(11, 3, 3, 15.00, '2024-12-01'),
(12, 3, 3, 18.90, '2024-12-01'),
(13, 3, 2, 19.99, '2024-12-02'),
(14, 3, 1, 22.50, '2024-12-03'),
(15, 3, 2, 19.99, '2024-12-04'),
(16, 3, 3, 18.90, '2024-12-05'),
(17, 1, 1, 5.99, '2024-12-05'),
(18, 2, 3, 8.50, '2024-12-06'),
(19, 1, 2, 22.50, '2024-12-06'),
(20, 3, 1, 30.00, '2024-12-07');
GO
