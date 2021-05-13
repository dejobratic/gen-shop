# gen-shop

Technical task

There is a customer (client) and a service provider.
  • The customer (or client) can be an individual or juridical person
  • The service provider is a legal entity

The purpose of the system is to issue an invoice correctly. The service provider invoices its customer.

When the service provider is not a VAT payer - VAT is not calculated on the amount of the order.

Where the supplier is a VAT payer and the customer:
  • Outside the EU - VAT is 0%
  • lives in the EU, is not a VAT payer, but lives in a different country from the service provider. VAT x% is applied, where x is the percentage of VAT applied in that country, for example: Lithuania 21% VAT
  • lives in the EU, is a VAT payer but lives in a different country from the service provider. 0% reverse charge applies.
  • when the customer and the service provider live in the same country, VAT always applies

The task does not require a user interface! Written unit tests are required with the help of xUnit, NUnit or MSTest. For Mock’s to use ms nsubstitute http://nsubstitute.github.io/

Platform - .Net Core.
