-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Mar 28, 2025 at 01:32 PM
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
(90, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-23 21:45:55'),
(91, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-23 21:53:52'),
(92, 'Admin', 'Administrator', 'Added product: Milo', 'ProductMain', '2025-03-23 21:54:47'),
(93, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-23 22:00:52'),
(94, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-23 22:03:26'),
(95, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-23 22:09:56'),
(96, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-23 22:17:20'),
(97, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-23 22:34:30'),
(98, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-23 22:36:20'),
(99, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-24 22:18:58'),
(100, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-24 22:23:12'),
(101, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-24 22:27:07'),
(102, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-24 22:40:56'),
(103, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-24 22:47:12'),
(104, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-24 22:50:19'),
(105, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-24 22:53:02'),
(106, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-24 22:54:30'),
(107, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-24 22:56:13'),
(108, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-24 22:56:38'),
(109, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-24 23:04:49'),
(110, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-24 23:06:32'),
(111, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-24 23:11:11'),
(112, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-24 23:14:09'),
(113, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-24 23:18:03'),
(114, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-24 23:20:24'),
(115, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-24 23:22:01'),
(116, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-24 23:23:15'),
(117, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-24 23:24:51'),
(118, 'Admin', 'Administrator', 'Added a new category: Food', 'CategoryMain', '2025-03-24 23:26:33'),
(119, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-25 21:12:48'),
(120, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-25 21:22:33'),
(121, 'Admin', 'Administrator', 'Edited the product: \r\n', 'ProductMain', '2025-03-25 21:25:16'),
(122, 'Admin', 'Administrator', 'Edited the product: \r\ndescription changed from \'Masarap\' to \'Masaraps\'\r\n', 'ProductMain', '2025-03-25 21:25:32'),
(123, 'Admin', 'Administrator', 'Deleted product: Milo', 'ProductMain', '2025-03-25 21:25:45'),
(124, 'Admin', 'Administrator', 'Added product: Milo', 'ProductMain', '2025-03-25 21:26:07'),
(125, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-25 21:28:15'),
(126, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-25 21:42:44'),
(127, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-25 21:44:51'),
(128, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-25 21:51:28'),
(129, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-25 21:51:48'),
(130, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-25 21:55:16'),
(131, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-25 21:56:12'),
(132, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-25 21:56:43'),
(133, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-25 22:00:41'),
(134, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-25 22:05:11'),
(135, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-25 22:06:08'),
(136, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-25 22:07:39'),
(137, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-25 22:08:47'),
(138, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-25 22:10:36'),
(139, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-25 22:11:29'),
(140, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-26 14:50:46'),
(141, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-26 14:57:24'),
(142, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-26 15:03:49'),
(143, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-26 15:06:23'),
(144, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-26 15:15:39'),
(145, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-26 15:18:54'),
(146, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-26 15:23:33'),
(147, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-26 15:27:50'),
(148, 'Admin', 'Administrator', 'Edited the product: \r\n', 'ProductMain', '2025-03-26 15:29:31'),
(149, 'Admin', 'Administrator', 'Edited the product: \r\n', 'ProductMain', '2025-03-26 15:30:26'),
(150, 'Admin', 'Administrator', 'Added product: Beverages', 'ProductMain', '2025-03-26 15:30:48'),
(151, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-26 15:34:30'),
(152, 'Admin', 'Administrator', 'Edited the product: \r\nsupplier_id changed from \'NULL\' to \'20\'\r\n', 'ProductMain', '2025-03-26 15:34:49'),
(153, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-26 15:35:58'),
(154, 'Admin', 'Administrator', 'Edited the product: \r\nsupplier_id changed from \'NULL\' to \'20\'\r\n', 'ProductMain', '2025-03-26 15:38:24'),
(155, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-26 15:38:49'),
(156, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-26 22:40:51'),
(157, 'Admin', 'Administrator', 'Edited the product: \r\nexpiration_option changed from \'With Expiration\' to \'Without Expiration\'\r\n', 'ProductMain', '2025-03-26 23:02:38'),
(158, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-26 23:06:15'),
(159, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-26 23:09:20'),
(160, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-26 23:13:39'),
(161, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-26 23:17:58'),
(162, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-26 23:18:33'),
(163, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-26 23:19:29'),
(164, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-26 23:22:24'),
(165, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-26 23:23:10'),
(166, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-26 23:27:54'),
(167, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-26 23:28:15'),
(168, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-26 23:32:08'),
(169, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-26 23:35:13'),
(170, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-26 23:42:03'),
(171, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-26 23:44:18'),
(172, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-26 23:44:54'),
(173, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-26 23:52:20'),
(174, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-28 18:51:39'),
(175, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-28 18:54:46'),
(176, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-28 18:56:03'),
(177, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-28 18:58:34'),
(178, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-28 19:03:02'),
(179, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-28 19:06:51'),
(180, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-28 19:12:04'),
(181, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-28 19:17:32'),
(182, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-28 19:30:32'),
(183, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-28 19:42:26'),
(184, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-28 19:44:12'),
(185, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-28 19:44:35'),
(186, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-28 19:57:45'),
(187, 'Admin', 'Administrator', 'Disposed 0 units of \'Milo\' with expiration date 2025-04-27', 'ExpirationMain', '2025-03-28 19:58:23'),
(188, 'Admin', 'Administrator', 'Disposed 2 units of \'Milo\' with expiration date 2025-03-28', 'ExpirationMain', '2025-03-28 19:58:36'),
(189, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-28 19:59:04'),
(190, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-28 19:59:51'),
(191, 'Cashier', 'joshua a arm (Cashier)', 'Voided 3 x Milo (Barcode: 12311) from transaction TXN-20250328201152. Total: $3,000.00', 'POS', '2025-03-28 20:12:24'),
(192, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-28 21:12:24'),
(193, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-28 21:16:05'),
(194, 'Admin', 'Administrator', 'Added product: Bear Brand', 'ProductMain', '2025-03-28 21:18:07'),
(195, 'Admin', 'Administrator', 'Disposed 50 units of \'Bear Brand\' with expiration date 2025-04-29', 'ExpirationMain', '2025-03-28 21:20:07'),
(196, 'Admin', 'Administrator', 'Logged out.', 'Logout', '2025-03-28 21:22:09'),
(197, 'Cashier', 'joshua a arm (Cashier)', 'Voided 1 x Milo (Barcode: 12311) from transaction TXN-20250328212216. Total: $1,000.00', 'POS', '2025-03-28 21:22:42'),
(198, 'Cashier', 'joshua a arm (Cashier)', 'Voided 1 x Beverages (Barcode: 22) from transaction TXN-20250328212245. Total: $200.00', 'POS', '2025-03-28 21:22:57');

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
(15, 'Beverages', 'List of Beverages', '2025-03-23 07:00:50', '2025-03-23 07:00:50'),
(17, 'Food', 'List of Foods', '2025-03-24 15:26:32', '2025-03-24 15:26:32');

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
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `status` enum('pending','received','cancelled') COLLATE utf8mb4_general_ci DEFAULT 'pending',
  `notes` text COLLATE utf8mb4_general_ci,
  `received_by` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `deliveries`
--

INSERT INTO `deliveries` (`delivery_id`, `supplier_id`, `transaction_number`, `delivery_date`, `received_date`, `created_at`, `updated_at`, `status`, `notes`, `received_by`) VALUES
(422, 20, 'TRX-20250326152904', '2025-03-26', NULL, '2025-03-26 07:29:15', '2025-03-26 07:29:15', 'received', 'sda', NULL),
(423, 20, 'TRX-20250328191228', '2025-03-28', NULL, '2025-03-28 11:12:40', '2025-03-28 11:12:40', 'received', '2000', NULL),
(424, 20, 'TRX-20250328191827', '2025-03-28', NULL, '2025-03-28 11:18:36', '2025-03-28 11:18:36', 'received', 'asdasd', NULL),
(425, 20, 'TRX-20250328193304', '2025-03-28', NULL, '2025-03-28 11:33:10', '2025-03-28 11:33:10', 'received', '2', NULL),
(426, 20, 'TRX-20250328211830', '2025-03-28', NULL, '2025-03-28 13:18:57', '2025-03-28 13:18:57', 'received', 'asdas', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `delivery_items`
--

CREATE TABLE `delivery_items` (
  `delivery_item_id` int NOT NULL,
  `delivery_id` int NOT NULL,
  `product_id` int NOT NULL,
  `quantity` int NOT NULL,
  `expiration_date` date DEFAULT NULL,
  `unit_price` decimal(10,2) NOT NULL,
  `batch_number` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `status` enum('active','expired','disposed') COLLATE utf8mb4_general_ci DEFAULT 'active'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `delivery_items`
--

INSERT INTO `delivery_items` (`delivery_item_id`, `delivery_id`, `product_id`, `quantity`, `expiration_date`, `unit_price`, `batch_number`, `status`) VALUES
(209, 422, 52, 99, NULL, '200.00', '2', 'active'),
(210, 423, 52, 1, '2025-03-28', '2.00', '2', 'active'),
(211, 424, 53, 20, NULL, '2.00', '211', 'active'),
(212, 425, 52, 1, '2025-03-28', '2.00', '22', 'active'),
(213, 426, 54, 100, '2025-03-29', '12.00', '1', 'active');

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

--
-- Dumping data for table `discounts`
--

INSERT INTO `discounts` (`discount_id`, `discount_name`, `discount_rate`, `start_date`, `end_date`, `created_at`, `updated_at`) VALUES
(20, 'Vat', '0.20', '2025-03-24', '2025-03-24', '2025-03-24 15:18:50', '2025-03-24 15:18:50'),
(21, 'Shopee', '0.10', '2025-03-28', '2025-03-28', '2025-03-28 13:20:57', '2025-03-28 13:20:57');

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

--
-- Dumping data for table `expiration_tracking`
--

INSERT INTO `expiration_tracking` (`tracking_id`, `product_id`, `quantity`, `expiration_date`) VALUES
(54, 54, 100, '2025-03-29');

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
  `disposed` bit(1) DEFAULT b'0',
  `minimum_stock` int DEFAULT '10',
  `maximum_stock` int DEFAULT '100',
  `last_delivery_date` date DEFAULT NULL,
  `last_stock_count` date DEFAULT NULL,
  `status` enum('in_stock','low_stock','out_of_stock') COLLATE utf8mb4_general_ci DEFAULT 'in_stock'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `inventory`
--

INSERT INTO `inventory` (`inventory_id`, `product_id`, `current_quantity`, `updated_at`, `expiration_date`, `reorder_level`, `disposed`, `minimum_stock`, `maximum_stock`, `last_delivery_date`, `last_stock_count`, `status`) VALUES
(102, 52, 99, '2025-03-28 11:58:36', NULL, NULL, b'0', 10, 100, NULL, NULL, 'in_stock'),
(103, 53, 20, '2025-03-28 11:18:36', NULL, NULL, b'0', 10, 100, NULL, NULL, 'in_stock'),
(104, 54, 50, '2025-03-28 13:20:07', NULL, NULL, b'0', 10, 100, NULL, NULL, 'in_stock');

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
(637, 'Admin', 'Administrator', 'Login', '2025-03-23 21:46:36'),
(638, 'Admin', 'Administrator', 'Login', '2025-03-23 21:54:07'),
(639, 'Admin', 'Administrator', 'Login', '2025-03-23 22:01:04'),
(640, 'Admin', 'Administrator', 'Login', '2025-03-23 22:03:38'),
(641, 'Admin', 'Administrator', 'Login', '2025-03-23 22:13:42'),
(642, 'Admin', 'Administrator', 'Login', '2025-03-23 22:32:43'),
(643, 'Admin', 'Administrator', 'Login', '2025-03-23 22:35:55'),
(644, 'Admin', 'Administrator', 'Login', '2025-03-24 22:17:49'),
(645, 'Admin', 'Administrator', 'Login', '2025-03-24 22:20:38'),
(646, 'Admin', 'Administrator', 'Login', '2025-03-24 22:23:28'),
(647, 'Admin', 'Administrator', 'Login', '2025-03-24 22:38:54'),
(648, 'Admin', 'Administrator', 'Login', '2025-03-24 22:46:30'),
(649, 'Admin', 'Administrator', 'Login', '2025-03-24 22:49:10'),
(650, 'Admin', 'Administrator', 'Login', '2025-03-24 22:52:19'),
(651, 'Admin', 'Administrator', 'Login', '2025-03-24 22:53:20'),
(652, 'Admin', 'Administrator', 'Login', '2025-03-24 22:54:53'),
(653, 'Admin', 'Administrator', 'Login', '2025-03-24 22:56:25'),
(654, 'Admin', 'Administrator', 'Login', '2025-03-24 22:59:33'),
(655, 'Admin', 'Administrator', 'Login', '2025-03-24 23:05:51'),
(656, 'Admin', 'Administrator', 'Login', '2025-03-24 23:06:46'),
(657, 'Admin', 'Administrator', 'Login', '2025-03-24 23:11:19'),
(658, 'Admin', 'Administrator', 'Login', '2025-03-24 23:14:18'),
(659, 'Admin', 'Administrator', 'Login', '2025-03-24 23:18:15'),
(660, 'Admin', 'Administrator', 'Login', '2025-03-24 23:20:38'),
(661, 'Admin', 'Administrator', 'Login', '2025-03-24 23:22:11'),
(662, 'Admin', 'Administrator', 'Login', '2025-03-24 23:23:28'),
(663, 'Admin', 'Administrator', 'Login', '2025-03-24 23:25:01'),
(664, 'Admin', 'Administrator', 'Login', '2025-03-24 23:25:58'),
(665, 'Admin', 'Administrator', 'Login', '2025-03-25 21:17:58'),
(666, 'Admin', 'Administrator', 'Login', '2025-03-25 21:25:02'),
(667, 'Admin', 'Administrator', 'Login', '2025-03-25 21:28:46'),
(668, 'Admin', 'Administrator', 'Login', '2025-03-25 21:44:14'),
(669, 'Admin', 'Administrator', 'Login', '2025-03-25 21:49:46'),
(670, 'Admin', 'Administrator', 'Login', '2025-03-25 21:51:42'),
(671, 'Admin', 'Administrator', 'Login', '2025-03-25 21:52:48'),
(672, 'Admin', 'Administrator', 'Login', '2025-03-25 21:55:31'),
(673, 'Admin', 'Administrator', 'Login', '2025-03-25 21:56:26'),
(674, 'Admin', 'Administrator', 'Login', '2025-03-25 22:00:10'),
(675, 'Admin', 'Administrator', 'Login', '2025-03-25 22:00:56'),
(676, 'Admin', 'Administrator', 'Login', '2025-03-25 22:05:26'),
(677, 'Admin', 'Administrator', 'Login', '2025-03-25 22:06:21'),
(678, 'Admin', 'Administrator', 'Login', '2025-03-25 22:08:32'),
(679, 'Admin', 'Administrator', 'Login', '2025-03-25 22:09:21'),
(680, 'Admin', 'Administrator', 'Login', '2025-03-25 22:10:55'),
(681, 'Admin', 'Administrator', 'Login', '2025-03-26 14:49:50'),
(682, 'Admin', 'Administrator', 'Login', '2025-03-26 14:52:58'),
(683, 'Admin', 'Administrator', 'Login', '2025-03-26 14:57:47'),
(684, 'Admin', 'Administrator', 'Login', '2025-03-26 15:04:06'),
(685, 'Admin', 'Administrator', 'Login', '2025-03-26 15:09:36'),
(686, 'Admin', 'Administrator', 'Login', '2025-03-26 15:15:52'),
(687, 'Admin', 'Administrator', 'Login', '2025-03-26 15:19:13'),
(688, 'Admin', 'Administrator', 'Login', '2025-03-26 15:24:55'),
(689, 'Admin', 'Administrator', 'Login', '2025-03-26 15:28:58'),
(690, 'Admin', 'Administrator', 'Login', '2025-03-26 15:34:43'),
(691, 'Admin', 'Administrator', 'Login', '2025-03-26 15:38:15'),
(692, 'Admin', 'Administrator', 'Login', '2025-03-26 22:36:30'),
(693, 'Admin', 'Administrator', 'Login', '2025-03-26 23:01:48'),
(694, 'Admin', 'Administrator', 'Login', '2025-03-26 23:06:33'),
(695, 'Admin', 'Administrator', 'Login', '2025-03-26 23:09:33'),
(696, 'Admin', 'Administrator', 'Login', '2025-03-26 23:13:52'),
(697, 'Admin', 'Administrator', 'Login', '2025-03-26 23:18:13'),
(698, 'Admin', 'Administrator', 'Login', '2025-03-26 23:19:10'),
(699, 'Admin', 'Administrator', 'Login', '2025-03-26 23:19:49'),
(700, 'Admin', 'Administrator', 'Login', '2025-03-26 23:22:37'),
(701, 'Admin', 'Administrator', 'Login', '2025-03-26 23:25:26'),
(702, 'Admin', 'Administrator', 'Login', '2025-03-26 23:28:05'),
(703, 'Admin', 'Administrator', 'Login', '2025-03-26 23:30:32'),
(704, 'Admin', 'Administrator', 'Login', '2025-03-26 23:32:20'),
(705, 'Admin', 'Administrator', 'Login', '2025-03-26 23:35:23'),
(706, 'Admin', 'Administrator', 'Login', '2025-03-26 23:42:11'),
(707, 'Admin', 'Administrator', 'Login', '2025-03-26 23:44:28'),
(708, 'Admin', 'Administrator', 'Login', '2025-03-26 23:45:37'),
(709, 'Admin', 'Administrator', 'Login', '2025-03-26 23:52:32'),
(710, 'Admin', 'Administrator', 'Login', '2025-03-28 18:47:41'),
(711, 'Admin', 'Administrator', 'Login', '2025-03-28 18:51:53'),
(712, 'Admin', 'Administrator', 'Login', '2025-03-28 18:55:01'),
(713, 'Admin', 'Administrator', 'Login', '2025-03-28 18:56:21'),
(714, 'Admin', 'Administrator', 'Login', '2025-03-28 18:58:55'),
(715, 'Admin', 'Administrator', 'Login', '2025-03-28 19:03:18'),
(716, 'Admin', 'Administrator', 'Login', '2025-03-28 19:07:03'),
(717, 'Admin', 'Administrator', 'Login', '2025-03-28 19:12:21'),
(718, 'Admin', 'Administrator', 'Login', '2025-03-28 19:18:12'),
(719, 'Admin', 'Administrator', 'Login', '2025-03-28 19:32:57'),
(720, 'Admin', 'Administrator', 'Login', '2025-03-28 19:42:52'),
(721, 'Admin', 'Administrator', 'Login', '2025-03-28 19:44:17'),
(722, 'Admin', 'Administrator', 'Login', '2025-03-28 19:45:01'),
(723, 'Admin', 'Administrator', 'Login', '2025-03-28 19:58:02'),
(724, 'Admin', 'Administrator', 'Login', '2025-03-28 19:59:48'),
(725, 'Cashier', 'joshua a arm', 'Login', '2025-03-28 20:00:00'),
(726, 'Cashier', 'joshua a arm', 'Login', '2025-03-28 20:11:52'),
(727, 'Admin', 'Administrator', 'Login', '2025-03-28 21:12:19'),
(728, 'Admin', 'Administrator', 'Login', '2025-03-28 21:12:38'),
(729, 'Admin', 'Administrator', 'Login', '2025-03-28 21:16:38'),
(730, 'Cashier', 'joshua a arm', 'Login', '2025-03-28 21:22:16'),
(731, 'Admin', 'Administrator', 'Login', '2025-03-28 21:24:36');

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
  `expiration_date` date DEFAULT NULL,
  `reorder_point` int DEFAULT '10',
  `unit_of_measure` varchar(20) COLLATE utf8mb4_general_ci DEFAULT 'piece',
  `is_active` tinyint(1) DEFAULT '1',
  `supplier_id` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`product_id`, `product_name`, `barcode`, `description`, `selling_price`, `cost_price`, `category_id`, `created_at`, `updated_at`, `expiration_option`, `expiration_date`, `reorder_point`, `unit_of_measure`, `is_active`, `supplier_id`) VALUES
(52, 'Milo', '12311', 'asdawd', '1000.00', '20000.00', 15, '2025-03-25 13:26:07', '2025-03-26 07:34:48', 'With Expiration', NULL, 10, 'piece', 1, 20),
(53, 'Beverages', '22', '22', '200.00', '200.00', 15, '2025-03-26 07:30:48', '2025-03-26 15:02:36', 'Without Expiration', NULL, 10, 'piece', 1, 20),
(54, 'Bear Brand', '11', 'Masarap', '12.00', '10.00', 15, '2025-03-28 13:18:07', '2025-03-28 13:18:07', 'With Expiration', NULL, 10, 'piece', 1, 20);

-- --------------------------------------------------------

--
-- Table structure for table `product_price_history`
--

CREATE TABLE `product_price_history` (
  `history_id` int NOT NULL,
  `product_id` int DEFAULT NULL,
  `old_cost_price` decimal(10,2) DEFAULT NULL,
  `new_cost_price` decimal(10,2) DEFAULT NULL,
  `old_selling_price` decimal(10,2) DEFAULT NULL,
  `new_selling_price` decimal(10,2) DEFAULT NULL,
  `change_date` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `changed_by` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
-- Table structure for table `stock_movements`
--

CREATE TABLE `stock_movements` (
  `movement_id` int NOT NULL,
  `product_id` int DEFAULT NULL,
  `movement_type` enum('delivery','sale','adjustment','disposal') DEFAULT NULL,
  `quantity` int DEFAULT NULL,
  `reference_id` varchar(50) DEFAULT NULL,
  `movement_date` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `performed_by` int DEFAULT NULL,
  `notes` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `stock_movements`
--

INSERT INTO `stock_movements` (`movement_id`, `product_id`, `movement_type`, `quantity`, `reference_id`, `movement_date`, `performed_by`, `notes`) VALUES
(1, 52, 'delivery', 99, '422', '2025-03-26 07:29:15', NULL, NULL),
(2, 52, 'delivery', 1, '423', '2025-03-28 11:12:43', NULL, NULL),
(3, 53, 'delivery', 20, '424', '2025-03-28 11:18:36', NULL, NULL),
(4, 52, 'delivery', 1, '425', '2025-03-28 11:33:10', NULL, NULL),
(5, 52, 'disposal', 0, 'DISP-20250328195823', '2025-03-28 11:58:23', 8, 'Disposed due to expiration - Date: 2025-04-27'),
(6, 52, 'disposal', 2, 'DISP-20250328195836', '2025-03-28 11:58:36', 8, 'Disposed due to expiration - Date: 2025-03-28'),
(7, 54, 'delivery', 100, '426', '2025-03-28 13:18:57', NULL, NULL),
(8, 54, 'disposal', 50, 'DISP-20250328212007', '2025-03-28 13:20:07', 8, 'Disposed due to expiration - Date: 2025-04-29');

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
  `updated_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `contact_person` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `payment_terms` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `tax_id` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `credit_limit` decimal(10,2) DEFAULT NULL,
  `status` enum('active','inactive') COLLATE utf8mb4_general_ci DEFAULT 'active',
  `lead_time` int DEFAULT NULL COMMENT 'Average delivery time in days',
  `rating` int DEFAULT NULL
) ;

--
-- Dumping data for table `suppliers`
--

INSERT INTO `suppliers` (`supplier_id`, `supplier_name`, `contact_number`, `address`, `email`, `created_at`, `updated_at`, `contact_person`, `payment_terms`, `tax_id`, `credit_limit`, `status`, `lead_time`, `rating`) VALUES
(20, 'Jack n Jill', '09602825151', '123 Mall', 'caleb@gmail.com', '2025-03-25 13:19:37', '2025-03-25 13:19:37', NULL, NULL, NULL, NULL, 'active', NULL, NULL);

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
  ADD KEY `supplier_id` (`supplier_id`),
  ADD KEY `received_by` (`received_by`);

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
  ADD KEY `category_id` (`category_id`),
  ADD KEY `supplier_id` (`supplier_id`);

--
-- Indexes for table `product_price_history`
--
ALTER TABLE `product_price_history`
  ADD PRIMARY KEY (`history_id`),
  ADD KEY `product_id` (`product_id`),
  ADD KEY `changed_by` (`changed_by`);

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
-- Indexes for table `stock_movements`
--
ALTER TABLE `stock_movements`
  ADD PRIMARY KEY (`movement_id`),
  ADD KEY `product_id` (`product_id`),
  ADD KEY `performed_by` (`performed_by`);

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
  MODIFY `AuditID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=199;

--
-- AUTO_INCREMENT for table `categories`
--
ALTER TABLE `categories`
  MODIFY `category_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT for table `deliveries`
--
ALTER TABLE `deliveries`
  MODIFY `delivery_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=427;

--
-- AUTO_INCREMENT for table `delivery_items`
--
ALTER TABLE `delivery_items`
  MODIFY `delivery_item_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=214;

--
-- AUTO_INCREMENT for table `discounts`
--
ALTER TABLE `discounts`
  MODIFY `discount_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT for table `expiration_tracking`
--
ALTER TABLE `expiration_tracking`
  MODIFY `tracking_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=56;

--
-- AUTO_INCREMENT for table `inventory`
--
ALTER TABLE `inventory`
  MODIFY `inventory_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=105;

--
-- AUTO_INCREMENT for table `loghistory`
--
ALTER TABLE `loghistory`
  MODIFY `LogID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=732;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `product_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=55;

--
-- AUTO_INCREMENT for table `product_price_history`
--
ALTER TABLE `product_price_history`
  MODIFY `history_id` int NOT NULL AUTO_INCREMENT;

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
-- AUTO_INCREMENT for table `stock_movements`
--
ALTER TABLE `stock_movements`
  MODIFY `movement_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `suppliers`
--
ALTER TABLE `suppliers`
  MODIFY `supplier_id` int NOT NULL AUTO_INCREMENT;

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
  ADD CONSTRAINT `deliveries_ibfk_1` FOREIGN KEY (`supplier_id`) REFERENCES `suppliers` (`supplier_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `deliveries_ibfk_2` FOREIGN KEY (`received_by`) REFERENCES `users` (`user_id`);

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
-- Constraints for table `products`
--
ALTER TABLE `products`
  ADD CONSTRAINT `products_ibfk_1` FOREIGN KEY (`supplier_id`) REFERENCES `suppliers` (`supplier_id`);

--
-- Constraints for table `product_price_history`
--
ALTER TABLE `product_price_history`
  ADD CONSTRAINT `product_price_history_ibfk_1` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`),
  ADD CONSTRAINT `product_price_history_ibfk_2` FOREIGN KEY (`changed_by`) REFERENCES `users` (`user_id`);

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

--
-- Constraints for table `stock_movements`
--
ALTER TABLE `stock_movements`
  ADD CONSTRAINT `stock_movements_ibfk_1` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`),
  ADD CONSTRAINT `stock_movements_ibfk_2` FOREIGN KEY (`performed_by`) REFERENCES `users` (`user_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
