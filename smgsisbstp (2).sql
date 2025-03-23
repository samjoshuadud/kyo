-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Mar 23, 2025 at 01:52 PM
-- Server version: 8.4.3
-- PHP Version: 8.3.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `smgsisbstp`
--

-- --------------------------------------------------------

--
-- Table structure for table `audittrail`
--

CREATE TABLE `audittrail` (
  `AuditID` int NOT NULL,
  `Role` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `FullName` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Action` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Form` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Date` datetime DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `audittrail`
--

INSERT INTO `audittrail` (`AuditID`, `Role`, `FullName`, `Action`, `Form`, `Date`) VALUES
(72, 'Admin', 'Administrator', 'Added a new category: Beverages', 'CategoryMain', '2025-03-23 15:00:52'),
(73, 'Admin', 'Administrator', 'Added a new category: Beveragess', 'CategoryMain', '2025-03-23 15:01:07'),
(74, 'Admin', 'Administrator', 'Deleted category: Beveragess', 'CategoryMain', '2025-03-23 15:01:11'),
(75, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-23 15:01:22'),
(76, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-23 15:05:14'),
(77, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-23 15:13:04'),
(78, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-23 15:19:52'),
(79, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-23 15:26:38'),
(80, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-23 15:28:57'),
(81, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-23 15:34:45'),
(82, 'Admin', 'Administrator', 'Added product: Milo', 'ProductMain', '2025-03-23 15:36:22'),
(83, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-23 15:36:30'),
(84, 'Admin', 'Administrator', 'Edited the product: \r\ndescription changed from \'assdas\' to \'assdasss\'\r\n', 'ProductMain', '2025-03-23 15:40:14'),
(85, 'Admin', 'Administrator', 'Deleted product: Milo', 'ProductMain', '2025-03-23 15:40:18'),
(86, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-23 21:19:14'),
(87, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-23 21:39:08'),
(88, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-23 21:41:46'),
(89, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-23 21:45:20'),
(90, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-23 21:45:55');

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE `categories` (
  `category_id` int NOT NULL,
  `category_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `description` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`category_id`, `category_name`, `description`, `created_at`, `updated_at`) VALUES
(15, 'Beverages', 'List of Beverages', '2025-03-23 07:00:50', '2025-03-23 07:00:50');

-- --------------------------------------------------------

--
-- Table structure for table `deliveries`
--

CREATE TABLE `deliveries` (
  `delivery_id` int NOT NULL,
  `supplier_id` int NOT NULL,
  `transaction_number` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `delivery_date` date NOT NULL,
  `received_date` date DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `delivery_items`
--

CREATE TABLE `delivery_items` (
  `delivery_item_id` int NOT NULL,
  `delivery_id` int NOT NULL,
  `product_id` int NOT NULL,
  `quantity` int NOT NULL,
  `expiration_date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `discounts`
--

CREATE TABLE `discounts` (
  `discount_id` int NOT NULL,
  `discount_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `discount_rate` decimal(5,2) NOT NULL,
  `start_date` date DEFAULT NULL,
  `end_date` date DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `expiration_tracking`
--

CREATE TABLE `expiration_tracking` (
  `tracking_id` int NOT NULL,
  `product_id` int NOT NULL,
  `quantity` int NOT NULL DEFAULT '0',
  `expiration_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `inventory`
--

CREATE TABLE `inventory` (
  `inventory_id` int NOT NULL,
  `product_id` int NOT NULL,
  `current_quantity` int NOT NULL DEFAULT '0',
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `expiration_date` date DEFAULT NULL,
  `reorder_level` int DEFAULT NULL,
  `disposed` bit(1) DEFAULT b'0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `loghistory`
--

CREATE TABLE `loghistory` (
  `LogID` int NOT NULL,
  `Role` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `FullName` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Action` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Date` datetime DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `loghistory`
--

INSERT INTO `loghistory` (`LogID`, `Role`, `FullName`, `Action`, `Date`) VALUES
(620, 'Admin', 'Administrator', 'Login', '2025-03-23 14:28:28'),
(621, 'Admin', 'Administrator', 'Login', '2025-03-23 14:38:20'),
(622, 'Admin', 'Administrator', 'Login', '2025-03-23 14:41:40'),
(623, 'Admin', 'Administrator', 'Login', '2025-03-23 14:51:36'),
(624, 'Admin', 'Administrator', 'Login', '2025-03-23 15:00:23'),
(625, 'Admin', 'Administrator', 'Login', '2025-03-23 15:05:10'),
(626, 'Admin', 'Administrator', 'Login', '2025-03-23 15:12:56'),
(627, 'Admin', 'Administrator', 'Login', '2025-03-23 15:18:40'),
(628, 'Admin', 'Administrator', 'Login', '2025-03-23 15:21:38'),
(629, 'Admin', 'Administrator', 'Login', '2025-03-23 15:26:49'),
(630, 'Admin', 'Administrator', 'Login', '2025-03-23 15:32:35'),
(631, 'Admin', 'Administrator', 'Login', '2025-03-23 15:34:59'),
(632, 'Admin', 'Administrator', 'Login', '2025-03-23 15:39:58'),
(633, 'Admin', 'Administrator', 'Login', '2025-03-23 21:36:20'),
(634, 'Admin', 'Administrator', 'Login', '2025-03-23 21:39:19'),
(635, 'Admin', 'Administrator', 'Login', '2025-03-23 21:42:05'),
(636, 'Admin', 'Administrator', 'Login', '2025-03-23 21:45:34'),
(637, 'Admin', 'Administrator', 'Login', '2025-03-23 21:46:36');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `product_id` int NOT NULL,
  `product_name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `barcode` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `description` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  `selling_price` decimal(10,2) NOT NULL,
  `cost_price` decimal(10,2) NOT NULL,
  `category_id` int DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `expiration_option` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `expiration_date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `sales`
--

CREATE TABLE `sales` (
  `sale_id` int NOT NULL,
  `transaction_number` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `sale_date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `cashier_id` int NOT NULL,
  `total_amount` decimal(10,2) NOT NULL,
  `discount_amount` decimal(10,2) DEFAULT '0.00',
  `vat_amount` decimal(10,2) DEFAULT '0.00',
  `net_amount` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `sale_items`
--

CREATE TABLE `sale_items` (
  `sale_item_id` int NOT NULL,
  `sale_id` int NOT NULL,
  `product_id` int NOT NULL,
  `quantity` int NOT NULL,
  `unit_price` decimal(10,2) NOT NULL,
  `total_price` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `suppliers`
--

CREATE TABLE `suppliers` (
  `supplier_id` int NOT NULL,
  `supplier_name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `contact_number` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `address` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  `email` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `user_id` int NOT NULL,
  `username` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `full_name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `email` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `password_hash` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `role` enum('Admin','Cashier','Staff') CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `address` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `age` int DEFAULT NULL,
  `gender` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `first_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `middle_initial` varchar(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `last_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `profile_picture` mediumblob
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`user_id`, `username`, `full_name`, `email`, `password_hash`, `role`, `created_at`, `updated_at`, `address`, `age`, `gender`, `first_name`, `middle_initial`, `last_name`, `profile_picture`) VALUES
(8, 'admin', 'Administrator', '', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 'Admin', '2024-11-26 07:48:37', '2024-11-26 07:48:37', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(54, 'cashier', 'cashierrrrr c cashierrrrr', 'test123@gmail.com', '6a79b51fec89db977e62d3b5aee3ea8b9de93cabf2446aae7d6f517db6d16178', 'Cashier', '2025-03-19 11:21:54', '2025-03-19 11:21:54', 'test123', 20, 'Male', 'cashierrrrr', 'c', 'cashierrrrr', NULL),
(55, 'cjcashier', 'joshua a arm', 'asd@mail.com', '5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', 'Cashier', '2025-03-19 13:34:32', '2025-03-19 13:34:32', 'asd', 20, 'Male', 'joshua', 'a', 'arm', NULL),
(56, 'cjstaff', 'cj ja jc', 'asd@gmail.com', '5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', 'Staff', '2025-03-19 13:35:13', '2025-03-19 13:35:13', 'dasd', 20, 'Male', 'cj', 'ja', 'jc', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `vat`
--

CREATE TABLE `vat` (
  `vat_id` int NOT NULL,
  `vat_rate` decimal(5,2) NOT NULL,
  `effective_date` date NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `vat`
--

INSERT INTO `vat` (`vat_id`, `vat_rate`, `effective_date`, `created_at`) VALUES
(15, '12.00', '0000-00-00', '2025-03-10 04:32:56');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `audittrail`
--
ALTER TABLE `audittrail`
  ADD PRIMARY KEY (`AuditID`);

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`category_id`);

--
-- Indexes for table `deliveries`
--
ALTER TABLE `deliveries`
  ADD PRIMARY KEY (`delivery_id`),
  ADD UNIQUE KEY `transaction_number` (`transaction_number`),
  ADD KEY `supplier_id` (`supplier_id`);

--
-- Indexes for table `delivery_items`
--
ALTER TABLE `delivery_items`
  ADD PRIMARY KEY (`delivery_item_id`),
  ADD KEY `delivery_id` (`delivery_id`),
  ADD KEY `product_id` (`product_id`);

--
-- Indexes for table `discounts`
--
ALTER TABLE `discounts`
  ADD PRIMARY KEY (`discount_id`);

--
-- Indexes for table `expiration_tracking`
--
ALTER TABLE `expiration_tracking`
  ADD PRIMARY KEY (`tracking_id`),
  ADD KEY `product_id` (`product_id`);

--
-- Indexes for table `inventory`
--
ALTER TABLE `inventory`
  ADD PRIMARY KEY (`inventory_id`),
  ADD KEY `product_id` (`product_id`);

--
-- Indexes for table `loghistory`
--
ALTER TABLE `loghistory`
  ADD PRIMARY KEY (`LogID`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`product_id`),
  ADD UNIQUE KEY `barcode` (`barcode`),
  ADD KEY `category_id` (`category_id`);

--
-- Indexes for table `sales`
--
ALTER TABLE `sales`
  ADD PRIMARY KEY (`sale_id`),
  ADD UNIQUE KEY `transaction_number` (`transaction_number`),
  ADD KEY `idx_cashier_id` (`cashier_id`);

--
-- Indexes for table `sale_items`
--
ALTER TABLE `sale_items`
  ADD PRIMARY KEY (`sale_item_id`),
  ADD KEY `sale_id` (`sale_id`),
  ADD KEY `product_id` (`product_id`);

--
-- Indexes for table `suppliers`
--
ALTER TABLE `suppliers`
  ADD PRIMARY KEY (`supplier_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`),
  ADD UNIQUE KEY `username` (`username`),
  ADD KEY `idx_user_id` (`user_id`);

--
-- Indexes for table `vat`
--
ALTER TABLE `vat`
  ADD PRIMARY KEY (`vat_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `audittrail`
--
ALTER TABLE `audittrail`
  MODIFY `AuditID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=91;

--
-- AUTO_INCREMENT for table `categories`
--
ALTER TABLE `categories`
  MODIFY `category_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `deliveries`
--
ALTER TABLE `deliveries`
  MODIFY `delivery_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=411;

--
-- AUTO_INCREMENT for table `delivery_items`
--
ALTER TABLE `delivery_items`
  MODIFY `delivery_item_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=204;

--
-- AUTO_INCREMENT for table `discounts`
--
ALTER TABLE `discounts`
  MODIFY `discount_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `expiration_tracking`
--
ALTER TABLE `expiration_tracking`
  MODIFY `tracking_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=52;

--
-- AUTO_INCREMENT for table `inventory`
--
ALTER TABLE `inventory`
  MODIFY `inventory_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=102;

--
-- AUTO_INCREMENT for table `loghistory`
--
ALTER TABLE `loghistory`
  MODIFY `LogID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=638;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `product_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=51;

--
-- AUTO_INCREMENT for table `sales`
--
ALTER TABLE `sales`
  MODIFY `sale_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=186;

--
-- AUTO_INCREMENT for table `sale_items`
--
ALTER TABLE `sale_items`
  MODIFY `sale_item_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=191;

--
-- AUTO_INCREMENT for table `suppliers`
--
ALTER TABLE `suppliers`
  MODIFY `supplier_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=57;

--
-- AUTO_INCREMENT for table `vat`
--
ALTER TABLE `vat`
  MODIFY `vat_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `deliveries`
--
ALTER TABLE `deliveries`
  ADD CONSTRAINT `deliveries_ibfk_1` FOREIGN KEY (`supplier_id`) REFERENCES `suppliers` (`supplier_id`) ON DELETE CASCADE;

--
-- Constraints for table `delivery_items`
--
ALTER TABLE `delivery_items`
  ADD CONSTRAINT `delivery_items_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`) ON DELETE CASCADE;

--
-- Constraints for table `expiration_tracking`
--
ALTER TABLE `expiration_tracking`
  ADD CONSTRAINT `expiration_tracking_ibfk_1` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`) ON DELETE CASCADE;

--
-- Constraints for table `sales`
--
ALTER TABLE `sales`
  ADD CONSTRAINT `sales_ibfk_1` FOREIGN KEY (`cashier_id`) REFERENCES `users` (`user_id`);

--
-- Constraints for table `sale_items`
--
ALTER TABLE `sale_items`
  ADD CONSTRAINT `sale_items_ibfk_1` FOREIGN KEY (`sale_id`) REFERENCES `sales` (`sale_id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
