using Irony.Parsing;
using System;

namespace CssIronyParser
{
    [Language("SCSS", "1.0", "")]
    public class ScssGrammar : Grammar
    {
        public ScssGrammar()
        {
            #region 1. Terminals

            var l_paran = ToTerm("{");
            var r_paran = ToTerm("}");
            var colon = ToTerm(":");
            var semicolon = ToTerm(";");
            var single_quote = ToTerm("'");
            var forward_slash = ToTerm("/");

            //  var name = new RegexBasedTerminal(@"([_a-zA-Z0-9-]|([^\0-\177])|((\[0-9a-f]{1,6}(\r\n|[ \n\r\t\f])?)|\[^\n\r\f0-9a-f]))+");
            ////   var ident = new RegexBasedTerminal(@"[-]?([_a-z]|[^\0-\177]|((\[0-9a-f]{1,6}(\r\n|[ \n\r\t\f])?)|\[^\n\r\f0-9a-f]))([_a-zA-Z0-9-]|[^\0-\177]|((\[0-9a-f]{1,6}(\r\n|[ \n\r\t\f])?)|\[^\n\r\f0-9a-f]))*");
            //    var S = new RegexBasedTerminal(@"[ \t\r\n\f]+");
            //var num = new RegexBasedTerminal(@"[+-]?([0-9]+|[0-9]*\.[0-9]+)(e[+-]?[0-9]+)?");
            //var string1 = new RegexBasedTerminal(@"""([^\n\r\f""]|\(\n|\r\n|\r|\f)|((\[0-9a-f]{1,6}(\r\n|[ \n\r\t\f])?)|\[^\n\r\f0-9a-f])*""");
            // var string2 = new RegexBasedTerminal(@"'([^\n\r\f']|\(\n|\r\n|\r|\f)|((\[0-9a-f]{1,6}(\r\n|[ \n\r\t\f])?)|\[^\n\r\f0-9a-f])*'");
            var comma = ToTerm(",");

            var color_rgb = new RegexBasedTerminal("colorRGB", @"#[0-9a-f]{1,6}");

            var comment = new CommentTerminal("COMMENT", "/*", "*/");
            var line_comment = new CommentTerminal("LINE_COMMENT", "//", "\n");

            var import = ToTerm("@import");
            var font = ToTerm("font");

            var import_file = new StringLiteral("import_file", "'");
            var font_name = new StringLiteral("font_name", "\"");

            //  var dashmatch = ToTerm(@"|=");
            //var includes = ToTerm(@"~=");

            //var uri_0 = new RegexBasedTerminal(@"(u|\0(0,4)(55|75)(\r\n|[ \t\r\n\f])?|\\u)(r|\0(0,4)(52|72)(\r\n|[ \t\r\n\f])?|\r)(l|\0(0,4)(4c|6c)(\r\n|[ \t\r\n\f])?|\\l)\(([ \t\r\n\f]*)((""([^\n\r\f\""]|\(\n|\r\n|\r|\f)|((\[0-9a-f]{1,6}(\r\n|[ \n\r\t\f])?)|\[^\n\r\f0-9a-f]))*"")|('([^\n\r\f\']|\(\n|\r\n|\r|\f)|((\[0-9a-f]{1,6}(\r\n|[ \n\r\t\f])?)|\[^\n\r\f0-9a-f]))*'([ \t\r\n\f]*)\)");
            //var uri_1 = new RegexBasedTerminal(@"(u|\0(0,4)(55|75)(\r\n|[ \t\r\n\f])?|\\u)(r|\0(0,4)(52|72)(\r\n|[ \t\r\n\f])?|\r)(l|\0(0,4)(4c|6c)(\r\n|[ \t\r\n\f])?|\\l)\(([ \t\r\n\f]*)([!#$%&*-\[\]-~]|([^\0-\177])|((\[0-9a-f]{1,6}(\r\n|[ \n\r\t\f])?)|\\[^\n\r\f0-9a-f]))*([ \t\r\n\f]*)\)");

            //var unicode_0 = new RegexBasedTerminal("unicode_0", @"u\+[?]{1,6}");
            //var unicode_1 = new RegexBasedTerminal("unicode_1", @"u\+[0-9a-f]{1}[?]{0,5}");
            //var unicode_2 = new RegexBasedTerminal("unicode_2", @"u\+[0-9a-f]{2}[?]{0,4}");
            //var unicode_3 = new RegexBasedTerminal("unicode_3", @"u\+[0-9a-f]{3}[?]{0,3}");
            //var unicode_4 = new RegexBasedTerminal("unicode_4", @"u\+[0-9a-f]{4}[?]{0,2}");
            //var unicode_5 = new RegexBasedTerminal("unicode_5", @"u\+[0-9a-f]{5}[?]{0,1}");
            //var unicode_6 = new RegexBasedTerminal("unicode_6", @"u\+[0-9a-f]{6}");
            //var unicode_7 = new RegexBasedTerminal("unicode_7", @"u\+[0-9a-f]{1,6}-[0-9a-f]{1,6}");

            var ident = new IdentifierTerminal("ident", "-");
            var NUMBER = new NumberLiteral("NUMBER", NumberOptions.DisableQuickParse);
            var css_number = new NumberLiteral("CSS_NUMBER", NumberOptions.AllowLetterAfter);
            var percentage = new RegexBasedTerminal("PERCENTAGE", @"[0-9]+[\%]");        
            var zero_terminal = new RegexBasedTerminal("ZERO_TERMINAL", @"[0]");

            NonGrammarTerminals.Add(comment);
            NonGrammarTerminals.Add(line_comment);

            #endregion

            #region 2. Non-terminals
            var CSS_UNIT = new NonTerminal("CSS_UNIT", ToTerm("px") | ToTerm("em"));
            var VAR_SYMBOL = new NonTerminal("VAR_SYMBOL", ToTerm("$"));
            var AT_SYMBOL = new NonTerminal("AT_SYMBOL", ToTerm("@"));
            var CDO = new NonTerminal("CDO", ToTerm("<!--"));
            var CDC = new NonTerminal("CDC", ToTerm("-->"));
            var DASHMATCH = new NonTerminal("dashmatch", ToTerm(@"|="));

            var PIXEL = new NonTerminal("PIXEL", ToTerm("px"));

            var CSS_UNIT_VALUE = new NonTerminal("CSS_UNIT_VALUE", css_number + PIXEL);
            //    //var DIMENSION = new NonTerminal("DIMENSION", num + ident);
            //   // var STRING = new NonTerminal("STRING", string1 | string2);
            //    //var HASH = new NonTerminal("HASH", ToTerm("#") + name);
            //    var URI = new NonTerminal("URI");           
            //    var UNICODE_RANGE = new NonTerminal("UNICODE-RANGE");
            //    //var FUNCTION = new NonTerminal("FUNCTION", ident + "(");


            var STATEMENT = new NonTerminal("STATEMENT");
            var STYLESHEET = new NonTerminal("STYLESHEET");

            var VAR_RULE = new NonTerminal("VAR_RULE");
            var VAR_PROPERTY = new NonTerminal("VAR_PROPERTY");
            var VAR_PROPERTY_DECLARATION = new NonTerminal("VAR_PROPERTY_DECLARATION");
            var VAR_DECLARATION_LIST = new NonTerminal("VAR_DECLARATION_LIST");
            var VAR_DECLARATION = new NonTerminal("VAR_DECLARATION");

            var BLOCK = new NonTerminal("BLOCK");
            var BLOCK_IDENTIFIER = new NonTerminal("BLOCK_IDENTIFIER");
            var BLOCK_IDENTIFIERS = new NonTerminal("BLOCK_IDENTIFIERS");
            var BLOCK_ITEMS = new NonTerminal("BLOCK_ITEMS");
            var BLOCK_ITEM = new NonTerminal("BLOCK_ITEM");
            var DECLARATION = new NonTerminal("DECLARATION");
            var PROPERTY = new NonTerminal("PROPERTY");
            var VALUE_ITEM_GROUP = new NonTerminal("VALUE_3");
            var VALUE = new NonTerminal("VALUE");
            var DECLARATION_VALUES = new NonTerminal("DECLARATION_VALUES");
            var VAR_REFERENCE = new NonTerminal("VAR_REFERENCE", VAR_SYMBOL + ident);

            var IMPORT_RULE = new NonTerminal("IMPORT_RULE");

            var FONT_GROUP = new NonTerminal("FONT_GROUP");
            var FONT_STYLE = new NonTerminal("FONT_STYLE");
            var FONT_VARIANT = new NonTerminal("FONT_VARIANT");
            var FONT_WEIGHT = new NonTerminal("FONT_WEIGHT");
            var FONT_SIZE = new NonTerminal("FONT_SIZE");
            var LINE_WEIGHT = new NonTerminal("LINE_WEIGHT");
            var FONT_FAMILY = new NonTerminal("FONT_FAMILY");
            var FONT_FAMILY_MEMBER = new NonTerminal("FONT_FAMILY_MEMBER");
            var UNIT_SIZE = new NonTerminal("UNIT_SIZE");
            var FONT_OPTIONAL = new NonTerminal("FONT_OPTIONAL");


            //    var var_declare_member = new NonTerminal("var_declare_member");
            //    var var_color = new NonTerminal("var_color");

            //    var value = new NonTerminal("value");
            //    var block = new NonTerminal("block");
            //    var any = new NonTerminal("any");
            //    var at_rule = new NonTerminal("at-rule");
            //    var any_star = new NonTerminal("any_star");
            //    var any_plus = new NonTerminal("any_plus");

            //    var unused = new NonTerminal("unused");

            //    var ruleset = new NonTerminal("ruleset");
            //    var selector = new NonTerminal("selector");
            //    var declaration = new NonTerminal("declaration");
            //    var property = new NonTerminal("property");

            //     var S_star = new NonTerminal("S_star");

            #endregion

            #region 3. BNF rules

            // WHITESPACE  
            //S_star.Rule = MakeStarRule(S_star, S);

            // var stylesheet_nonstar = CDO | CDC | statement;
            STYLESHEET.Rule = MakeStarRule(STYLESHEET, STATEMENT);

            STATEMENT.Rule = VAR_RULE | BLOCK | IMPORT_RULE;

            ////var_declaration
            ////var_declaration.Rule = var_property + S_star + var_separator + S_star;
            VAR_RULE.Rule = VAR_PROPERTY + colon + VAR_PROPERTY_DECLARATION + semicolon;
            VAR_PROPERTY.Rule = VAR_SYMBOL + ident;
            VAR_PROPERTY_DECLARATION.Rule = VAR_DECLARATION_LIST | color_rgb;
            VAR_DECLARATION_LIST.Rule = MakePlusRule(VAR_DECLARATION_LIST, comma, VAR_DECLARATION);
            VAR_DECLARATION.Rule = ident;

            //block       : '{' S* [ any | block | ATKEYWORD S* | ';' S* ]* '}' S*;
            BLOCK.Rule = BLOCK_IDENTIFIERS + l_paran + BLOCK_ITEMS + r_paran;
            BLOCK_IDENTIFIERS.Rule = MakePlusRule(BLOCK_IDENTIFIERS, comma, BLOCK_IDENTIFIER);

            BLOCK_IDENTIFIER.Rule = ident | AT_SYMBOL + ident;
            BLOCK_ITEMS.Rule = MakeStarRule(BLOCK_ITEMS, BLOCK_ITEM);
            BLOCK_ITEM.Rule = BLOCK | FONT_GROUP | DECLARATION;

            //declaration : property S* ':' S* value;
            //
            DECLARATION.Rule = PROPERTY + colon + DECLARATION_VALUES;

            //property    : IDENT;
            //
            PROPERTY.Rule = ident;

            DECLARATION_VALUES.Rule = VALUE + semicolon;
;

            //PERCENTAGE.Precedence = 1;

            VALUE.Rule = MakePlusRule(VALUE, VALUE_ITEM_GROUP);
           // VALUE_1.Precedence = 4;

            VALUE_ITEM_GROUP.Rule =  percentage | VAR_REFERENCE | CSS_UNIT_VALUE | zero_terminal | color_rgb | ident | "none" | "block" | "inline-block";
           // VALUE.Precedence = 3;

            CSS_UNIT_VALUE.Rule = css_number + CSS_UNIT;
            //VALUE_2.Precedence = 1;

            VAR_REFERENCE.Rule = VAR_SYMBOL + ident;

            IMPORT_RULE.Rule = import + import_file + semicolon;

            FONT_GROUP.Rule = font + colon + FONT_STYLE + FONT_VARIANT + FONT_WEIGHT + FONT_SIZE + FONT_FAMILY + semicolon;

            FONT_STYLE.Rule = Empty
                //   | "normal"
                | "italic"
                | "oblique";
            //| "initial"
            //| "inherit";

            FONT_VARIANT.Rule = Empty
                //   | "normal" 
                | "small-caps";
              //  | "initial"
             //   | "inherit";

            FONT_WEIGHT.Rule = Empty
                //| "normal"
                | "bold"
                | "bolder"
                | "lighter"
                //| "initial"
                //| "inherit"
                | "100"
                | "200"
                | "300"
                | "400"
                | "500"
                | "600"
                | "700"
                | "800"
                | "900";

            FONT_SIZE.Rule = UNIT_SIZE + forward_slash + LINE_WEIGHT | UNIT_SIZE;
            UNIT_SIZE.Rule = percentage | CSS_UNIT_VALUE;
            LINE_WEIGHT.Rule = UNIT_SIZE;           
       
            FONT_FAMILY.Rule = VAR_REFERENCE | MakePlusRule(FONT_FAMILY, comma, FONT_FAMILY_MEMBER);
            FONT_FAMILY_MEMBER.Rule = ident | font_name | "sans-serif" | "serif" | "monospace" | "cursive" | "fantasy" | "caption" | "icon" | "menu" | "message-box" | "small-caption" | "status-bar";


            //var_color.Rule = color_rgb;
            //var_declare_members.Rule = MakePlusRule(var_declare_members, comma, var_declare_member);
            //var_declare_member.Rule = IDENT;
            /**
            URI.Rule = uri_0 | uri_1;

            UNICODE_RANGE.Rule = unicode_0
                                | unicode_1
                                | unicode_2
                                | unicode_3
                                | unicode_4
                                | unicode_5
                                | unicode_6
                                | unicode_7;
            //block       : '{' S* [ any | block | ATKEYWORD S* | ';' S* ]* '}' S*;
            //
            **
            var block_grp = any | block | ATKEYWORD + S_star | ";" + S_star;
            var block_grp_star = new NonTerminal("block_grp_star");
            block_grp_star.Rule = MakeStarRule(block_grp_star, block_grp);
            block.Rule = ToTerm("{") + S_star + block_grp_star + "}" + S_star;

            //at-rule     : ATKEYWORD S* any* [ block | ';' S* ];
            //
            var at_rule_grp = block | ";" + S_star;
            at_rule.Rule = ATKEYWORD + S_star + any_star + at_rule_grp;

            //value       : [ any | block | ATKEYWORD S* ]+;
            //
            var value_grp = any | block | ATKEYWORD + S_star;
            var value_grp_plus = new NonTerminal("value_grp_plus");
            value_grp_plus.Rule = MakePlusRule(value_grp_plus, value_grp);
            value.Rule = value_grp_plus;

            //any         : [ IDENT | NUMBER | PERCENTAGE | DIMENSION | STRING
            //                | DELIM | URI | HASH | UNICODE-RANGE | INCLUDES
            //                | DASHMATCH | ':' | FUNCTION S* [any|unused]* ')'
            //                | '(' S* [any|unused]* ')' | '[' S* [any|unused]* ']'
            //                ] S*; 
            
            var anyORunused = any | unused;
            var anyORunused_star = new NonTerminal("anyORunused_star");
            anyORunused_star.Rule = MakeStarRule(anyORunused_star, anyORunused);

            var any_grp = IDENT | NUMBER | PERCENTAGE | DIMENSION | STRING
                        | URI | HASH | UNICODE_RANGE | INCLUDES
                        | DASHMATCH | ":" | FUNCTION + S_star + anyORunused_star + ")"
                        | "(" + S_star + anyORunused_star + ")"
                        | "[" + S_star + anyORunused_star + "]"
                        ;

            any.Rule = any_grp + S_star;
            any_star.Rule = MakeStarRule(any_star, any);
            any_plus.Rule = MakePlusRule(any_plus, any);

            //unused      : block | ATKEYWORD S* | ';' S* | CDO S* | CDC S*;
            //
            unused.Rule = block | ATKEYWORD + S_star | ";" + S_star | CDO + S_star | CDC + S_star;

            //ruleset     : selector? '{' S* declaration? [ ';' S* declaration? ]* '}' S*;
            //
            var ruleset_grp = ToTerm(";") + S_star + declaration.Q();
            var ruleset_grp_star = new NonTerminal("ruleset_grp_star");
            ruleset_grp_star.Rule = MakeStarRule(ruleset_grp_star, ruleset_grp);
            ruleset.Rule = selector.Q() + "{" + S_star + declaration.Q() + ruleset_grp_star + "}" + S_star;

            //selector    : any+;
            //
            //var selector_plus = new NonTerminal("selector_plus");
            //selector_plus.Rule = MakePlusRule(selector_plus, selector);
            selector.Rule = any_plus;

            //declaration : property S* ':' S* value;
            //
            declaration.Rule = property + S_star + ":" + S_star + value;

            //property    : IDENT;
            //
            property.Rule = IDENT;
         **/
            #endregion

            MarkPunctuation(colon, semicolon, l_paran, r_paran, single_quote);
            MarkTransient(VAR_SYMBOL, VAR_PROPERTY_DECLARATION, VAR_DECLARATION, VALUE_ITEM_GROUP, BLOCK_ITEM, PROPERTY, DECLARATION_VALUES);
            MarkReservedWords("none", "block", "inline-block", "font");

            //Set grammar root
            this.Root = STYLESHEET;
        }
    }
}
